using Feliv_auth.Models;
using Feliv_auth.Services;
using FeliveryAPI.Models;

namespace FeliveryAPI.Repository
{
    public interface IParentStoreService : IRepository<Restaurant> , IUserService
    {
    
    }
}
