using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IMenuItemService : IRepository<MenuItem>
    {
        public string UploadImage(IFormFile? Img, string StoreName, string MenuItemName);
        public List<MenuItem> MenuItemOffer();
        

    }
}
