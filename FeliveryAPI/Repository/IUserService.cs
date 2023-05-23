using Feliv_auth.Models;

namespace Feliv_auth.Services
{
    public interface IUserService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);

    }
}
