using Blog.IBLL;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        public override void SetDal()
        {
            this.dal = DalFactory.ArticleDalFactory.GetArticleDal();
        }
    }
}
