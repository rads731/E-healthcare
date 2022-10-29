using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EHealthcare.Entities
{
    public class Order : BaseEntity
    {
        [ForeignKey("Id")]
        [Required]
        public long UserID { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PlacedOn { get; set; }

        public virtual User User { get; set; }
    }
}
