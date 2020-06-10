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
    /// 粉丝和作者对应关系表
    /// </summary>
    public class FansInfo:BaseEntity
    {
        [Required,ForeignKey(nameof(User))]
        public Guid FansId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        public UserInfo User { get; set; }
    }
}
