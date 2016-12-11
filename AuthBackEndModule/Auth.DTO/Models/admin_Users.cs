using System;
using System.Collections.Generic;

namespace Auth.DTO.Models
{
    public partial class admin_Users : BaseDto
    {
        public System.Guid UserTypeId { get; set; }
        public Nullable<System.Guid> OrganisationId { get; set; }
        public string SSCId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool Active { get; set; }
        public bool IsBanned { get; set; }
        public Nullable<System.DateTime> EndBannedDate { get; set; }
        public bool IsOnline { get; set; }
        public string Avatar { get; set; }
        public Nullable<long> BillerId { get; set; }
    }
}
