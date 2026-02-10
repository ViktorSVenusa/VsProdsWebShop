using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsProdsWebShop.Infrastructure.Data.Entities;
using VsProdsWebShop.Infrastucture.Data;

namespace VsProdsWebShop.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);


            var dataCategory = serviceScope.ServiceProvider
       .GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            


            return app;
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }


        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();

                user.FirstName = "admin";
                user.LastName = "admin";
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.Address = "admin address";
                user.PhoneNumber = "0888888888";

                var result = await userManager.CreateAsync
                    (user, "Admin123456");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }


        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }

            dataCategory.Categories.AddRange(new[]
            {
                new Category { CategoryName = "Photography" },
                new Category { CategoryName = "Videography" },
                new Category { CategoryName = "Video Editing" },

            });

            dataCategory.SaveChanges();
        }


        private static void SeedServices(ApplicationDbContext context)
        {
            if (context.ServicesAvailable.Any())
                return;

            var photo = context.Categories.First(c => c.CategoryName == "Photography");
            var video = context.Categories.First(c => c.CategoryName == "Videography");
            var edit = context.Categories.First(c => c.CategoryName == "Video Editing");

            context.ServicesAvailable.AddRange(

                // Photography
                new ServiceAvailable
                {
                    ServiceName = "Wedding Photography",
                    CategoryId = photo.Id,
                    Price = 150,
                    ServiceDescription = "Wedding photo session",
                    Picture = "wedding-photo.jpg"
                },

                new ServiceAvailable
                {
                    ServiceName = "Portrait Photography",
                    CategoryId = photo.Id,
                    Price = 60,
                    ServiceDescription = "Portrait photoshoot",
                    Picture = "portrait.jpg"
                },

                // Videography
                new ServiceAvailable
                {
                    ServiceName = "Wedding Video",
                    CategoryId = video.Id,
                    Price = 300,
                    ServiceDescription = "Wedding videography",
                    Picture = "wedding-video.jpg"
                },

                // Editing
                new ServiceAvailable
                {
                    ServiceName = "Short Form Video",
                    CategoryId = edit.Id,
                    Price = 30,
                    ServiceDescription = "TikTok / Reels edit",
                    Picture = "shortform.jpg"
                },

                new ServiceAvailable
                {
                    ServiceName = "Video Package (5 videos)",
                    CategoryId = edit.Id,
                    Price = 120,
                    ServiceDescription = "Package editing",
                    Picture = "package.jpg"
                }
            );

            context.SaveChanges();
        }




    }
}
