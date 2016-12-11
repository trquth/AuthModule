using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Auth.DTO.Models.Mapping;

namespace Auth.DTO.Models
{
    public partial class ADMINMODULContext : DbContext
    {
        static ADMINMODULContext()
        {
            Database.SetInitializer<ADMINMODULContext>(null);
        }

        public ADMINMODULContext()
            : base("Name=ADMINMODULContext")
        {
        }

        public DbSet<admin_User_Tokens> admin_User_Tokens { get; set; }
        public DbSet<admin_Users> admin_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new admin_User_TokensMap());
            modelBuilder.Configurations.Add(new admin_UsersMap());
        }
    }
}
