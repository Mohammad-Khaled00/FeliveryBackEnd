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
    public class StoreService : IStoreService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _IConfiguration;
        private readonly IWebHostEnvironment _environment;

        public IDbContextFactory<ElDbContext> Context { get; }

        public StoreService(UserManager<IdentityUser> userManager, IConfiguration _IConfig, IDbContextFactory<ElDbContext> context, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _IConfiguration = _IConfig;
            Context = context;
            _environment = environment;
        }

        public List<Restaurant> GetAll()
        {
            List<Restaurant> RestaurantsList = new();
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantsList = customContext.Restaurants.Where(s => s.Status == "ApprovedStore").ToList();
            }
            using (var customContext = Context.CreateDbContext())
            {
                foreach (var rest in RestaurantsList)
                {
                    rest.IdentityUser = customContext.Users.First(r => r.Id == rest.SecurityID);
                }
            }
            return RestaurantsList;
        }

        public Restaurant? GetDetails(int id)
        {
            Restaurant RestaurantDetails = new();
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantDetails = customContext.Restaurants.Find(id);
            }
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantDetails.IdentityUser = customContext.Users.First(r => r.Id == RestaurantDetails.SecurityID);
            }
            return RestaurantDetails;
        }

        public void Update(Restaurant restaurant)
        {
            Restaurant DiffRouteData = new();
            using (var customContext = Context.CreateDbContext())
            {
                DiffRouteData = customContext.Restaurants.Find(restaurant.Id);
            }
            using (var customContext = Context.CreateDbContext())
            {
                customContext.Restaurants.Update(restaurant);
                restaurant.SecurityID = DiffRouteData.SecurityID;
                restaurant.StoreImg = DiffRouteData.StoreImg;
                restaurant.Status = DiffRouteData.Status;
                restaurant.Type = DiffRouteData.Type;
                restaurant.TotalRatings = DiffRouteData.TotalRatings;
                restaurant.NumOfRaters = DiffRouteData.NumOfRaters;
                customContext.SaveChanges();
            }
        }

        public Restaurant Delete(int id)
        {
            if (id == 0)
            {
                throw new Exception("ID is Invalid");
            }
            using var customContext = Context.CreateDbContext();
            if (customContext.Restaurants.Find(id) != null)
            {
                Restaurant RestaurantDetails = customContext.Restaurants.Find(id);
                var UserDetails = customContext.Users.Find(RestaurantDetails.SecurityID);
                var StoreFolder = _environment.WebRootPath + "\\Uploads\\Product\\" + UserDetails.UserName;
                customContext.Restaurants.Remove(RestaurantDetails);
                customContext.Users.Remove(UserDetails);
                if (Directory.Exists(StoreFolder))
                    Directory.Delete(StoreFolder, true);
                customContext.SaveChanges();
                return RestaurantDetails;
            }
            else
            {
                throw new Exception("Restaurant Not Found");
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
                Data.Restaurant.SecurityID = res.Id;
                Data.Restaurant.Status = res.Roles[0];
                Data.Restaurant.NumOfRaters = 0;
                Data.Restaurant.TotalRatings = 0;
                Insert(Data.Restaurant);
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

        public string UploadImage(IFormFile Img, string Storename)
        {
            using (var customContext = Context.CreateDbContext())
            {
                if (customContext.Restaurants.Where(r => r.Name == Storename).First() == null)
                    throw new Exception("Store Name Not Found");
            }
            if (Img != null)
            {
                string ImageUrl = string.Empty;
                string HostUrl = "https://localhost:44309/";
                string RawName = Storename.Replace(" ", "-");
                string filePath = _environment.WebRootPath + "\\Uploads\\Product\\" + RawName;
                string imagepath = filePath + "\\StoreImg.png";
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                if (Directory.Exists(imagepath))
                    Directory.Delete(imagepath);
                using (FileStream fileStream = File.Create(imagepath))
                {
                    Img.CopyTo(fileStream);
                }
                ImageUrl = HostUrl + "/uploads/Product/" + RawName + "/storeimg.png";
                using (var customContext = Context.CreateDbContext())
                {
                    var storeImg = customContext.Restaurants.Where(r => r.Name == Storename).First();
                    storeImg.StoreImg = ImageUrl;
                    customContext.SaveChanges();
                }
                return ImageUrl;
            }
            else
                throw new Exception("Image Not Found");
        }

        //Stastics--
        public async Task<IEnumerable<Restaurant>> Search(string name)
        {
            using var customContext = Context.CreateDbContext();

            IQueryable<Restaurant> query = customContext.Restaurants;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            return await query.ToListAsync();
        }

        public List<Restaurant> PendingStore()
        {
            List<Restaurant> RestaurantsList = new();
            using (var customContext = Context.CreateDbContext())
            {
                RestaurantsList = customContext.Restaurants.Where(s => s.Status == "PendingStore").ToList();
            }
            using (var customContext = Context.CreateDbContext())
            {
                foreach (var rest in RestaurantsList)
                {
                    rest.IdentityUser = customContext.Users.First(r => r.Id == rest.SecurityID);
                }
            }
            return RestaurantsList;
        }

        public async Task<IEnumerable<Order>> GetOrdersBystoreID(int storeID)
        {
            List<Order> Orders;
            List<OrderDetails> ODetails;
            using (var customContext = Context.CreateDbContext())
            {
                Orders = await customContext.Orders.Where(o => o.RestaurantID == storeID && o.Status == false).ToListAsync();
                foreach (var order in Orders)
                {
                    ODetails = customContext.OrderDetails.Where(o => o.OrderId == order.Id).ToList();
                    foreach (var Detail in ODetails)
                    {
                        order.Details.Add(Detail);
                    }
                }
            }
            return Orders;
        }

        public async Task<IEnumerable<Order>> GetFinshedOrdersBystoreID(int storeID)
        {
            List<Order> Orders;
            List<OrderDetails> ODetails;
            using (var customContext = Context.CreateDbContext())
            {
                Orders = await customContext.Orders.Where(o => o.RestaurantID == storeID && o.Status == true).ToListAsync();
                foreach (var order in Orders)
                {
                    ODetails = customContext.OrderDetails.Where(o => o.OrderId == order.Id).ToList();
                    foreach (var Detail in ODetails)
                    {
                        order.Details.Add(Detail);
                    }
                }
            }
            return Orders;
        }

        public async Task<IEnumerable<MenuItem>> GetmenuitemsBystoreID(int storeID)
        {
            List<MenuItem> MenuItems;
            using (var customContext = Context.CreateDbContext())
            {
                MenuItems = await customContext.MenuItems.Include(m => m.Category).Where(m => m.RestaurantID == storeID).ToListAsync();
            }
            return MenuItems;
        }

        public async Task<IEnumerable<MenuItem>> GetOffersBystoreID(int storeID)
        {
            List<MenuItem> OfferItems;
            using (var customContext = Context.CreateDbContext())
            {
                OfferItems = await customContext.MenuItems.Include(m => m.Category).Where(m => m.RestaurantID == storeID && m.IsOffer == true).ToListAsync();
            }
            return OfferItems;
        }

        public async Task<IEnumerable<Category>> GetCategoriesBystoreID(int storeID)
        {
            List<Category> Categories;
            using (var customContext = Context.CreateDbContext())
            {
                Categories = await customContext.Categories.Where(m => m.RestaurantID == storeID).ToListAsync();
            }
            return Categories;
        }

        public async Task <int> TotalEarnings(int storeID)
        {
            List<Order> Orders;
            int Earnings = 0;
            using (var customContext = Context.CreateDbContext())
            {
                Orders = await customContext.Orders.Where(o => o.RestaurantID == storeID && o.Status == true).ToListAsync();
                foreach (var order in Orders)
                {
                    Earnings += order.TotalPrice;
                }
            }
            return Earnings;
        }

        public async Task<int> TotalPendingOrders(int storeID)
        {
            List<Order> Orders;
            using (var customContext = Context.CreateDbContext())
            {
                Orders = await customContext.Orders.Where(o => o.RestaurantID == storeID && o.Status == false).ToListAsync();
            }
            return Orders.Count;
        }

        public async Task<int> TotalDeliveredOrders(int storeID)
        {
            List<Order> Orders;
            using (var customContext = Context.CreateDbContext())
            {
                Orders = await customContext.Orders.Where(o => o.RestaurantID == storeID && o.Status == true).ToListAsync();
            }
            return Orders.Count;
        }

        public void DoneOrder(int orderID)
        {
            using var customContext = Context.CreateDbContext();
            var FinishedOrder = customContext.Orders.Where(o => o.Id == orderID).First();
            FinishedOrder.Status = true;
            customContext.SaveChanges();
        }

        public void SetRate(int rate, int Storeid)
        {
            using var customContext = Context.CreateDbContext();
            var store = customContext.Restaurants.Where(r => r.Id == Storeid).First();
            int totalRating = store.TotalRatings + rate;
            int numOfRates = store.NumOfRaters +1;
            store.TotalRatings = totalRating;
            store.NumOfRaters = numOfRates;
            customContext.SaveChanges();
        }

        //Middle Functions--
        public void Insert(Restaurant restaurant)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Restaurants.Add(restaurant);
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
