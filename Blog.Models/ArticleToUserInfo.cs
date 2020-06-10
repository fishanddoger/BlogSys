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
    /// 文章和用户对应关系表
    /// </summary>
    public class ArticleToUserInfo:BaseEntity
    {
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public UserInfo User { get; set; }

        [Required,ForeignKey(nameof(ArticleInfo))]
        public Guid ArticleId { get; set; }

        public Article ArticleInfo { get; set; }
    }
}
