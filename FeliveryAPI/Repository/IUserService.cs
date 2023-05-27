using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IUserService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
    }
}
