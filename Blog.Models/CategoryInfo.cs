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
    /// 文章类别表
    /// </summary>
    public class CategoryInfo:BaseEntity
    {
        [Required,StringLength(50,MinimumLength =1),Column(TypeName ="varchar")]
        public string CategoryName { get; set; }

        [Required,ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public UserInfo User { get; set; }
    }
}
