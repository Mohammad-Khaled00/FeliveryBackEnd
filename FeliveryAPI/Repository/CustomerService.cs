using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace FeliveryAPI.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _IConfiguration;
        public IDbContextFactory<ElDbContext> Context { get; }

        public CustomerService(UserManager<IdentityUser> userManager, IConfiguration _IConfig, IDbContextFactory<ElDbContext> context)
        {
            _userManager = userManager;
            _IConfiguration = _IConfig;
            Context = context;
        }

        public List<Customer> GetAll()
        {
            List<Customer> CustomersList = new();
            using (var customContext = Context.CreateDbContext())
            {
                CustomersList = customContext.Customers.ToList();
            }
            using (var customContext = Context.CreateDbContext())
            {
                foreach (var custr in CustomersList)
                {
                    custr.IdentityUser = customContext.Users.First(r => r.Id == custr.SecurityID);
                }
            }
            return CustomersList;
        }

        public Customer? GetDetails(int id)
        {
            Customer CustomerDetails = new();
            using (var customContext = Context.CreateDbContext())
            {
                CustomerDetails = customContext.Customers.Find(id);
            }
            using (var customContext = Context.CreateDbContext())
            {
                CustomerDetails.IdentityUser = customContext.Users.First(r => r.Id == CustomerDetails.SecurityID);
            }
            return CustomerDetails;
        }

        public void Update(Customer customer)
        {
            string SecID;
            using (var customContext = Context.CreateDbContext())
            {
                var DiffRouteData = customContext.Customers.Find(customer.Id);
                SecID = DiffRouteData.SecurityID;
            }
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Customers.Update(customer);
                customer.SecurityID = SecID;
                customContext.SaveChanges();
            }
        }

        public Customer Delete(int id)
        {
            if (id == 0)
            {
                throw new Exception("ID is Invalid");
            }
            using var customContext = Context.CreateDbContext();
            if (customContext.Customers.Find(id) != null)
            {
                Customer CustomerDetails = customContext.Customers.Find(id);
                var UserDetails = customContext.Users.Find(CustomerDetails.SecurityID);
                customContext.Customers.Remove(CustomerDetails);
                customContext.Users.Remove(UserDetails);
                customContext.SaveChanges();
                return CustomerDetails;
            }
            else
            {
                throw new Exception("Customer Not Found");
            }
        }

        public async Task<AuthModel> Register(RegData Data)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                TransactionManager.ImplicitDistributedTransactions = true;
                TransactionInterop.GetTransmitterPropagationToken(Transaction.Current);
                var res = await RegisterAsync(Data.Model);
                if (res.Message != null)
                {
                    throw new Exception(res.Message);
                }
                Data.Customer.SecurityID = res.Id;
                Insert(Data.Customer);
                transaction.Complete();
                return new AuthModel
                {
                    Username = res.Username,
                    Email = res.Email,
                    Roles = res.Roles,
                    IsAuthenticated = res.IsAuthenticated,
                    Token = res.Token,
                    ExpiresOn = res.ExpiresOn
                };
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                return new AuthModel { Message = ex.Message };
            }
        }

        //Middle Functions--
        public void Insert(Customer t)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Customers.Add(t);
            customContext.SaveChanges();
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            model.Username = model.Username.Replace(" ", "-");
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Username is already registered!" };

            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Id = user.Id,
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Customer" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(IdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

            var Key = _IConfiguration["JWT:key"];
            var issuer = _IConfiguration["JWT:issuer"];
            var audience = _IConfiguration["JWT:Audience"];
            var dur = _IConfiguration["JWT:DurationInDays"];
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(double.Parse(dur)),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}