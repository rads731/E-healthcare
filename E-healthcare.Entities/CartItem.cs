using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EHealthcare.Entities
{
    public class CartItem : BaseEntity
    {
        [ForeignKey("Id")]
        [Required]
        public long CartID { get; set; }

        public long ProductID { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
