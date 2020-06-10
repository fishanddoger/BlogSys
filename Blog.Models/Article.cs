using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Article:BaseEntity
    {
        [Required,StringLength(200,MinimumLength =1)]
        public string Titile { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int GoodCount { get; set; } = 0;

        public int BadCount { get; set; } = 0;
    }
}
