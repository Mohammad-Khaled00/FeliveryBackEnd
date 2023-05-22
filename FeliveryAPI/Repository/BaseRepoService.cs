using FeliveryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class BaseRepoService
    {
        public IDbContextFactory<ElDbContext> Context { get; set; }

        public BaseRepoService(IDbContextFactory<ElDbContext> context)
        {
            Context = context;
        }
    }
}
