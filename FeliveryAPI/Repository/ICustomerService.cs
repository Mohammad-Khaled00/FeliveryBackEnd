using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface ICustomerService : IRepository<Customer>, IUserService
    {
        Task<AuthModel> Register(RegData Data);
    }
}
