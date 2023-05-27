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
            return CustomersList;
        }
        public Customer? GetDetails(int id)
        {
            Customer CustomerDetails = new();
            using (var customContext = Context.CreateDbContext())
            {
                CustomerDetails = customContext.Customers.Find(id);
            }
            return CustomerDetails;
        }

        public void Update(Customer customer)
        {

            using var customContext = Context.CreateDbContext();
            customContext.Customers.Update(customer);
            customContext.SaveChanges();
        }
        public void Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Customers.Remove(customContext.Customers.Find(id));
            customContext.SaveChanges();
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
                    throw new Exception("An error occurred.");
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
        //-------

        public void Insert(Customer t)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Customers.Add(t);
            customContext.SaveChanges();
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
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