using Blog.BLLFactory;
using Blog.IBLL;
using Blog.Models;
using Blog.UI.Portal.Models.ViewModel;
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

        IUserInfoService service = UserInfoServiceFactory.GetUserInfoService();

        [HttpPost]
        public ActionResult Register(string Email, string Password,string SiteName)
        {
            
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

        [HttpGet]
        public ActionResult UserList()
        {

            return View(service.GetAll().ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email,string pwd)
        {
            if (service.GetList(e => e.Email == email && e.Password == pwd).Count() > 0)
            {
                return Content("登陆成功");
            }
            else
            {
                return Content("登陆失败");
            }
        }

    }
}