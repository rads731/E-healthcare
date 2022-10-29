using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EHealthcare.Entities
{
    public class BaseEntity
    {
        [Key]
        public long ID { get; set; }
    }
}
