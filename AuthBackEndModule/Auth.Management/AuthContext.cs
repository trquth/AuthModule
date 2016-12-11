using Microsoft.AspNet.Identity.EntityFramework;

namespace Auth.Management
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {
     
        }
    }

}