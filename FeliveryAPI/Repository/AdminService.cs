using FeliveryAPI.Data;
using FeliveryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FeliveryAPI.Repository
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IDbContextFactory<ElDbContext> Context { get; }

        public AdminService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IDbContextFactory<ElDbContext> context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            Context = context;
        }
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var AllRoles = new[] { "Admin", "ApprovedStore", "PendingStore", "Customer" };
            var userRole = await _userManager.GetRolesAsync(user);

            foreach (var role in AllRoles)
            {
                if (userRole.Contains(role))
                    await _userManager.RemoveFromRoleAsync(user, role);
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);
            using var customContext = Context.CreateDbContext();
            try
            {
                var PromotedStore = customContext.Restaurants.Where(s => s.SecurityID == model.UserId && s.Status == "PendingStore" && model.Role == "ApprovedStore").First();
                PromotedStore.Status = "ApprovedStore";
                customContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Not Store");
            }
            return result.Succeeded ? string.Empty : "Sonething went wrong";
        }
    }
}
