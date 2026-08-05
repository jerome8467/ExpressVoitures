using Microsoft.AspNetCore.Identity;

namespace ExpressVoitures.Data
{
    public static class IdentitySeedData
    {
        private const string AdminEmail = "admin@expressvoitures.fr";
        private const string AdminPassword = "Password123!";

        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser? user = await userManager.FindByEmailAsync(AdminEmail);

            if (user == null)
            {
                user = new IdentityUser { UserName = AdminEmail, Email = AdminEmail };
                await userManager.CreateAsync(user, AdminPassword);
            }
        }
    }
}
