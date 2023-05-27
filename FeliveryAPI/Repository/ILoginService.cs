using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface ILoginService
    {
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

    }
}
