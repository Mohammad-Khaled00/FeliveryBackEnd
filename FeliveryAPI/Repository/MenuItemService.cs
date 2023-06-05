using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class MenuItemService : IMenuItemService
    {
        public IDbContextFactory<ElDbContext> Context { get; }
        private readonly IWebHostEnvironment _environment;

        public MenuItemService(IDbContextFactory<ElDbContext> context, IWebHostEnvironment environment)
        {
            Context = context;
            _environment = environment;
        }

        public List<MenuItem> GetAll()
        {
            List<MenuItem> MenuItemList = new();
            List<Restaurant> restlist = new();
            using (var customContext = Context.CreateDbContext())
            {
                //restlist = customContext.Restaurants.Where(m => m.Status == "ApprovedStore").ToList();

                MenuItemList = customContext.MenuItems.Where(m => m.Restaurant.Status == "ApprovedStore").ToList();
            }
            using (var customContext = Context.CreateDbContext())
            {
                foreach (var MenuItem in MenuItemList)
                {
                    MenuItem.Restaurant = customContext.Restaurants.First(r => r.Id == MenuItem.RestaurantID);
                    MenuItem.Category = customContext.Categories.First(c => c.Id == MenuItem.CategoryID);
                }
            }
            return MenuItemList;
        }

        public MenuItem? GetDetails(int id)
        {
            var MenuItemDetails = new MenuItem();
            using (var customContext = Context.CreateDbContext())
            {
                MenuItemDetails = customContext.MenuItems.Find(id);
            }
            using (var customContext = Context.CreateDbContext())
            {
                MenuItemDetails.Restaurant = customContext.Restaurants.First(r => r.Id == MenuItemDetails.RestaurantID);
                MenuItemDetails.Category = customContext.Categories.First(r => r.Id == MenuItemDetails.CategoryID);
            }
            return (MenuItemDetails);
        }

        public void Insert(MenuItem menuitem)
        {
            using var customContext = Context.CreateDbContext();
            if (customContext.MenuItems.Where(r => r.RestaurantID == menuitem.RestaurantID).Any(m => m.Name == menuitem.Name))
            {
                throw new Exception ("Menu Item Name already Exist!");
            }
            customContext.MenuItems.Add(menuitem);
            customContext.SaveChanges();
        }

        public void Update(MenuItem menuitem)
        {
            string MItImg;
            using (var customContext = Context.CreateDbContext())
            {
                MenuItem DiffRouteData = customContext.MenuItems.Find(menuitem.Id);
                MItImg = DiffRouteData.MenuItemImg;
            }
            using (var customContext = Context.CreateDbContext())
            {
                customContext.MenuItems.Update(menuitem);
                menuitem.MenuItemImg = MItImg;
                customContext.SaveChanges();
            }
        }

        public MenuItem Delete(int id)
        {
            MenuItem Item = new();
            var store = new Restaurant();
            string MenuItemImg;
            using (var customContext = Context.CreateDbContext())
            {
                if (customContext.MenuItems.Find(id) == null)
                    throw new Exception("Menu Item Not Found");
                Item = customContext.MenuItems.Find(id);
                store = customContext.Restaurants.Where(r => r.Id == Item.RestaurantID).First();
                string RawItemName = Item.Name.Replace(" ", "-");
                string RawStoreName = store.Name.Replace(" ", "-");
                MenuItemImg = _environment.WebRootPath + "\\Uploads\\Product\\" + RawStoreName + "\\Menu\\" + $"{RawItemName}.png";
            }
            using (var customContext = Context.CreateDbContext())
            {
                customContext.MenuItems.Remove(new MenuItem() { Id = id });
                if (File.Exists(MenuItemImg))
                    File.Delete(MenuItemImg);
                customContext.SaveChanges();
            }
            return Item;
        }

        public string UploadImage(IFormFile? Img, int StoreId, string MenuItemName)
        {
            if (MenuItemName == null)
                throw new Exception("Menu Item Name Not Found");
            string ImageUrl = string.Empty;
            string HostUrl = "https://localhost:44309/";
            string RawName = MenuItemName.Replace(" ", "-");
            string RawStoreName = string.Empty;
            using (var customContext = Context.CreateDbContext())
            {
                RawStoreName = customContext.Restaurants.Where(r => r.Id == StoreId).Select(r => r.Name).First().Replace(" ", "-");
            }
            string filePath = _environment.WebRootPath + "\\Uploads\\Product\\" + RawStoreName + "\\Menu\\";
            string imagepath = filePath + $"{RawName}.png";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            if (File.Exists(imagepath))
                File.Delete(imagepath);
            if (Img != null)
            {
                using (FileStream fileStream = File.Create(imagepath))
                {
                    Img.CopyTo(fileStream);
                }
                using (var customContext = Context.CreateDbContext())
                {
                    ImageUrl = HostUrl + "/uploads/Product/" + RawStoreName + $"/Menu/{RawName}.png";
                    var MenuItemImg = customContext.MenuItems.Where(r => r.Name == MenuItemName).First();
                    MenuItemImg.MenuItemImg = ImageUrl;
                    customContext.SaveChanges();
                }
                return ImageUrl;
            }
            else
            {
                using (var customContext = Context.CreateDbContext())
                {
                    ImageUrl = HostUrl + "/uploads/common/noimg.png";
                    var MenuItemImg = customContext.MenuItems.Where(r => r.Name == MenuItemName).First();
                    MenuItemImg.MenuItemImg = ImageUrl;
                    customContext.SaveChanges();
                }
                return ImageUrl;
            }
        }


        public List<MenuItem> MenuItemOffer()
        {
            List<MenuItem> MenuItemList = new();

            using (var customContext = Context.CreateDbContext())
            {
                MenuItemList = customContext.MenuItems.Where(s => s.IsOffer == true).ToList();
            }
            return MenuItemList;
        }
    }
}
