using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [Required]
        public bool IsDelete { get; set; } = false;
    }
}
