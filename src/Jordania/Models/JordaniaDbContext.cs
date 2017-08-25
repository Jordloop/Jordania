using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jordania.Models
{
    public class JordaniaDbContext : IdentityDbContext<ApplicationUser>
    {
        public JordaniaDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}