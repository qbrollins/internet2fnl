using Microsoft.AspNetCore.Identity;

namespace vize.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
