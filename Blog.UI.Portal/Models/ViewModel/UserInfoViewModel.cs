using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.UI.Portal.Models.ViewModel
{
    public class UserInfoViewModel
    {
        [Required,EmailAddress,StringLength(50,MinimumLength =6),Display(Name ="电子邮箱")]
        public string  Email { get; set; }

        [Required,DataType(DataType.Password),StringLength(30,MinimumLength = 6),Display(Name ="密码")]
        public string Password { get; set; }

        [Compare(nameof(Password)),DataType(DataType.Password),Display(Name ="确认密码")]
        public string CheckPwd { get; set; }

        [Required,StringLength(30,MinimumLength =1),Display(Name ="昵称")]
        public string SiteName { get; set; }
    }
}