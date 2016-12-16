using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Entities
{
    [Table("admin_Users")]
    public partial class Users : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool IsBanned { get; set; }
        public Nullable<System.DateTime> EndBannedDate { get; set; }
        public bool IsOnline { get; set; }
    }
}
