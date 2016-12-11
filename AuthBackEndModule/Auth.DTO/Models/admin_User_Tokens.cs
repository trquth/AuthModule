using System;
using System.Collections.Generic;

namespace Auth.DTO.Models
{
    public partial class admin_User_Tokens
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public string SessionId { get; set; }
        public string Token { get; set; }
        public bool IsValid { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public System.DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
    }
}
