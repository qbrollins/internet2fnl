using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vize.API.Models;

namespace vize.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Surway> surways { get; set; }
        public DbSet<SurwaysQuestion> SurwaysQuestion { get; set; }


    }
}
