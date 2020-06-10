using Blog.BLL;
using Blog.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLLFactory
{
    public class UserInfoServiceFactory
    {
        public static IUserInfoService GetUserInfoService()
        {
            IUserInfoService service = new UserInfoService();

            return service;
        }
    }
}
