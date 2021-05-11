using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Models
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
