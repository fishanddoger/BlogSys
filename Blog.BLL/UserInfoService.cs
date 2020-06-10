using Blog.DalFactory;
using Blog.IBLL;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL
{
    public class UserInfoService : BaseService<UserInfo>,IUserInfoService
    {
        public override void SetDal()
        {
            this.dal = UserInfoDalFactory.GetUserInfoDal();
        }
    }
}
