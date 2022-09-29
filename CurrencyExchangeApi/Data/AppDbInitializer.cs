using CurrencyExchangeApi.Data.Static;
using CurrencyExchangeApi.Models;
using Microsoft.AspNetCore.Identity;

namespace CurrencyExchangeApi.Data
{
    public class AppDbInitializer
    {
        //public static void Seed(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        //        context.Database.EnsureCreated();

        //        //Cinema
        //        if (!context.Cinemas.Any())
        //        {
        //            context.Cinemas.AddRange(new List<Cinema>()
        //            {
        //                new Cinema()
        //                {
        //                    Name = "Cinema 1",
        //                    Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
        //                    Description = "This is the description of the first cinema"
        //                },
        //                new Cinema()
        //                {
        //                    Name = "Cinema 2",
        //                    Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
        //                    Description = "This is the description of the first cinema"
        //                },
        //                new Cinema()
        //                {
        //                    Name = "Cinema 3",
        //                    Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
        //                    Description = "This is the description of the first cinema"
        //                },
        //                new Cinema()
        //                {
        //                    Name = "Cinema 4",
        //                    Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
        //                    Description = "This is the description of the first cinema"
        //                },
        //                new Cinema()
        //                {
        //                    Name = "Cinema 5",
        //                    Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
        //                    Description = "This is the description of the first cinema"
        //                },
        //            });
        //            context.SaveChanges();
        //        }
        //        //Actors
        //        if (!context.Actors.Any())
        //        {
        //            context.Actors.AddRange(new List<Actor>()
        //            {
        //                new Actor()
        //                {
        //                    FullName = "Actor 1",
        //                    Bio = "This is the Bio of the first actor",
        //                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

        //                },
        //                new Actor()
        //                {
        //                    FullName = "Actor 2",
        //                    Bio = "This is the Bio of the second actor",
        //                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
        //                },
        //                new Actor()
        //                {
        //                    FullName = "Actor 3",
        //                    Bio = "This is the Bio of the second actor",
        //                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
        //                },
        //                new Actor()
        //                {
        //                    FullName = "Actor 4",
        //                    Bio = "This is the Bio of the second actor",
        //                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
        //                },
        //                new Actor()
        //                {
        //                    FullName = "Actor 5",
        //                    Bio = "This is the Bio of the second actor",
        //                    ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
        //                }
        //            });
        //            context.SaveChanges();
        //        }

        //    }

        //}

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUserModel>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUserModel()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUserModel()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}


