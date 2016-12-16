using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Entities
{
    [Table("admin_Clients")]
    public partial class Clients : BaseEntity
    {      
        public string Secret { get; set; }
        public string Name { get; set; }
        public int ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }
       
    }
}
