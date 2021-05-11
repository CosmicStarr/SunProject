using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SunProject.Extenisons
{
    public static class UserManagerExtension
    {
        public async static Task<AppUser> FindUserProperties(this UserManager<AppUser> Input,ClaimsPrincipal User)
        {
            var UserEmail = User.FindFirstValue(ClaimTypes.Email);

            return await Input.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == UserEmail);
        }
        public async static Task<AppUser> FindUserProperty(this UserManager<AppUser> Input, ClaimsPrincipal User)
        {
            var UserEmail = User.FindFirstValue(ClaimTypes.Email);

            return await Input.Users.FirstOrDefaultAsync(x => x.Email == UserEmail);
        }
    }
}
