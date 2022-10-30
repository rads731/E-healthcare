
using ProjectManagement.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EHealthcare.Entities
{
    public class Cart : BaseEntity
    {
        [ForeignKey("Id")]
        [Required]
        public long OwnerID { get; set; }

        public virtual Users Owner { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
    }
}
