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
    /// 用户表
    /// </summary>
    public class UserInfo:BaseEntity
    {
        [Required,StringLength(50),Column(TypeName ="varchar")]
        public string Email { get; set; }

        [Required,StringLength(50),Column(TypeName ="varchar")]
        public string Password { get; set; }

        public int FansCount { get; set; } = 0;

        [StringLength(200), Column(TypeName = "varchar")]
        public string ImagePath { get; set; } = @"\imgages\default.jpg";

        [Required,StringLength(50),Column(TypeName ="varchar")]
        public string SiteName { get; set; }
    }
}
