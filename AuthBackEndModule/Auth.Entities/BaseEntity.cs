using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Entities
{
    public class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
