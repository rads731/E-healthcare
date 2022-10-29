using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EHealthcare.Entities
{
    public class Category : BaseEntity
    {
        [ForeignKey("Id")]
        [Required]
        public long ID { get; set; }

        public string Name { get; set; }
    }
}
