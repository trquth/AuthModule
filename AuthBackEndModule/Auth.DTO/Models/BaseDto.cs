using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DTO.Models
{
    public class BaseDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public BaseDto()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}
