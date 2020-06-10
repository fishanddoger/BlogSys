using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    /// <summary>
    /// 文章和类别对应关系表
    /// </summary>
    public class ArticleToCategory : BaseEntity
    {
        [Required, ForeignKey(nameof(ArticleInfo))]
        public Guid ArticleId { get; set; }

        public Article ArticleInfo { get; set; }

        [Required,ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        public CategoryInfo Category { get; set; }
    }
}
