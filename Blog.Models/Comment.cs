using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Comment:BaseEntity
    {
        [Required,StringLength(500,MinimumLength =1),Column(TypeName ="varchar")]
        public string CommentContent { get; set; }

        [Required,ForeignKey(nameof(ArticleInfo))]
        public Guid ArticleId { get; set; }

        public Article ArticleInfo { get; set; }

    }
}
