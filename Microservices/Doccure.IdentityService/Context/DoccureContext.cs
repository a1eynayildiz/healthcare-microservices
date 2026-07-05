using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Doccure.IdentityService.Context
{
    public class DoccureContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; initial catalog=DoccureIdentityDb; Trusted_Connection=True;TrustServerCertificate=True; ");

        }
        public DoccureContext(DbContextOptions<DoccureContext> options) : base(options)
        {
        }
    }
}