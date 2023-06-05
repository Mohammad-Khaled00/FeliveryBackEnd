using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IMenuItemService : IRepository<MenuItem>
    {
        public string UploadImage(IFormFile? Img, int StoreId, string MenuItemName);
        public List<MenuItem> MenuItemOffer();
        

    }
}
