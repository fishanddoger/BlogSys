using Blog.BLLFactory;
using Blog.IBLL;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Email, string Password,string SiteName)
        {
            IUserInfoService service = UserInfoServiceFactory.GetUserInfoService();
            if (ModelState.IsValid)
            {
                service.AddAsync(new UserInfo() { Email = Email, Password = Password,SiteName=SiteName});

                return Content("ok");
            }
            else
            {
                throw new Exception("发生异常");
            }
            
        }
    }
}