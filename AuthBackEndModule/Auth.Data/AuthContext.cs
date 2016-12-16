using Auth.Entities;
using System.Data.Entity;

namespace Auth.Data
{
    public partial class AuthContext : DbContext
    {
        public AuthContext()
            : base("name=AuthContext")
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
    }
}
