using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FeliveryAPI.Repository
{
    public class StoreService : IStoreService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _IConfiguration;
        public IDbContextFactory<ElDbContext> Context { get; }

        public StoreService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration _IConfig, IDbContextFactory<ElDbContext> context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _IConfiguration = _IConfig;
            Context = context;
        }
        public List<Restaurant> GetAll()
        {
            List<Restaurant> RestaurantsList = new();

            using (var customContext = Context.CreateDbContext())
            {
                RestaurantsList = customContext.Restaurants.ToList();
            }

            return RestaurantsList;
        }

        public Restaurant? GetDetails(int id)
        {
            var RestaurantDetails = new Restaurant();
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantDetails = customContext.Restaurants.Find(id);
            }
            return RestaurantDetails;

        }

        public void Insert(Restaurant restaurant)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Restaurants.Add(restaurant);
            customContext.SaveChanges();
        }

        public void Update(Restaurant restaurant)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Restaurants.Update(restaurant);
            customContext.SaveChanges();
        }
        public void Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Restaurants.Remove(customContext.Restaurants.Find(id));
            customContext.SaveChanges();
        }
        //-------
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

            await _userManager.AddToRoleAsync(user, "PendingStore");

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthModel
            {
                Id = user.Id,
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "PendingStore" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            using var customContext = Context.CreateDbContext();
            var localID = customContext.Restaurants.Where(d => d.SecurityID == user.Id).Select(d => d.Id).First();
            authModel.Id = $"{localID}";
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();
            return authModel;
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var AllRoles = new[] { "Admin", "ApprovedStore", "PendingStore", "Customer" };
            var userRole = await _userManager.GetRolesAsync(user);

            foreach (var role in AllRoles)
            {
                if (userRole.Contains(role))
                    await _userManager.RemoveFromRoleAsync(user, role);
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Sonething went wrong";
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

        public async Task<AuthModel> Register(RegData Data)
        {
            using TransactionScope transaction = new(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                TransactionManager.ImplicitDistributedTransactions = true;
                TransactionInterop.GetTransmitterPropagationToken(Transaction.Current);
                //Insert(Data.restaurant);
                //var result = RegisterAsync(Data.model);
                //Task.WaitAll(result);
                var res = await RegisterAsync(Data.model);
                if (res.Message != null)
                {
                    throw new Exception("An error occurred.");
                }
                Data.restaurant.SecurityID = res.Id;
                Insert(Data.restaurant);
                transaction.Complete();
                return new AuthModel{
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
    }
    public class RegData
    {
        public RegisterModel model { get; set; }
        public Restaurant restaurant { get; set; }
    }
}
