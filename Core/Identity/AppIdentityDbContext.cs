using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Identity
{
    public class AppIdentityDbContext : IdentityDbContext
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }
        public DbSet<Address> GetAddresses { get; set; }
        public DbSet<AppUser> GetAppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "1",
                DisplayName = "Normand",
                Email = "Normand@yahoo.com",
                UserName = "Normanj85",
            });
            builder.Entity<Address>().HasData(new Address
            {
                AddressId = 1,
                FirstName = "Normand",
                LastName = "Jean",
                Street = "2020 E 61st St,",
                City = "Brooklyn",
                State = "New York",
                ZipCode = "11234",  
                AppUserId = "1"
            });
           
     
        }
    }
}
