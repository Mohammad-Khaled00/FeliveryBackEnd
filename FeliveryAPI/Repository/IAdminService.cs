using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IAdminService
    {
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
