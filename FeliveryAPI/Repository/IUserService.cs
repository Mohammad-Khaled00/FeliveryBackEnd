using Feliv_auth.Models;

namespace FeliveryAPI.Models
{
    public interface IUserService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);

    }
}
