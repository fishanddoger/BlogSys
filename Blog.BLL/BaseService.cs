using Blog.IDAL;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL
{
    public abstract class BaseService<T> where T:BaseEntity
    {
        public IBaseDal<T> dal { get; set; }
        public abstract void SetDal();

        public BaseService()
        {
            SetDal();
        }

        public async Task<T> AddAsync(T model)
        {
            return await dal.AddAsync(model);
        }

        public async Task<bool> UpdateAsync(T model)
        {
            return await dal.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(T model)
        {
            return await dal.DeleteAsync(model);
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await dal.DeleteByIdAysnc(id);
        }

        public T GetOne(Guid id)
        {
            return dal.GetOne(id);
        }

        public IQueryable<T> GetAll()
        {
            return dal.GetAllEntities();
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereStr)
        {
            return dal.GetList(whereStr);
        }

        public IQueryable<T> GetAllByPage(int pageSize, int pageIndex, bool asc)
        {
            return dal.GetEntitiesByPage(pageSize, pageIndex, asc);
        }

        public IQueryable<T> GetListByPageWithWhere(int pageSize, int pageIndex, bool asc, Expression<Func<T, bool>> whereStr)
        {
            return dal.GetEntitiesByPageWithWhere(pageSize, pageIndex, whereStr, asc);
        }
    }
}
