using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var User = new AppUser
                {
                    DisplayName = "Normand",
                    Email = "Normand@yahoo.com",
                    UserName = "Normanj85",
                    Address = new Address
                    {
                        FirstName = "Normand",
                        LastName = "Jean",
                        Street= "2020 E 61st St,",
                        City = "Brooklyn",
                        State = "New York",
                        ZipCode = "11234"
                    }
                };

                await userManager.CreateAsync(User, "Sonics123");
            }
            
        }
    }
}
