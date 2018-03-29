using InsuranceQuotePortal.Data;
using InsuranceQuotePortal.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;

namespace InsuranceQuotePortal.Webapp.Infrastructure
{
    public class SeedUsers
    {
        public async static void Initialize(IApplicationBuilder app)
        {
            IServiceScopeFactory scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                var adminEmail = "admin@admin.com";

                if (!userManager.Users.Any(u => u.UserName == adminEmail))
                {
                    var result = await userManager.CreateAsync(new ApplicationUser
                    {
                        Email = adminEmail,
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        UserName = adminEmail,
                        NormalizedUserName = "OWNER",
                        PhoneNumber = "+111111111111",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    }, "Ab@12345");
                }
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                string[] roles = new string[] { "Admin", "Customer" };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        await roleStore.CreateAsync(new IdentityRole(role));
                    }
                }
                await FilterRoles(userManager, adminEmail, new[] { "Admin" });
            }
        }

        
        private static async Task FilterRoles(UserManager<ApplicationUser> userManager, string email, IEnumerable<string> roles)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            foreach (var r in roles) {
                if(!await userManager.IsInRoleAsync(user, r))
                    userManager.AddToRolesAsync(user, new [] { r });
            }
        }
        

    }
}
