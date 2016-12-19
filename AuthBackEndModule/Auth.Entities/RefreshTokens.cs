using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Entities
{
    [Table("admin_Refresh_Tokens")]
    public partial class RefreshTokens : BaseEntity
    {
        public string Subject { get; set; }
        public System.Guid ClientId { get; set; }
        public System.DateTime IssuedUtc { get; set; }
        public System.DateTime ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
