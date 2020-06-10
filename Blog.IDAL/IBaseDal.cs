using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IDAL
{
    public interface IBaseDal<T> where T : BaseEntity
    {
        IQueryable<T> GetAllEntities();

        T GetOne(Guid id);

        IQueryable<T> GetList(Expression<Func<T, bool>> whereStr);

        IQueryable<T> GetEntitiesByPage(int pageSize, int pageIndex, bool asc = true);

        IQueryable<T> GetEntitiesByPageWithWhere(int pageSize, int pageIndex,Expression<Func<T,bool>> whereStr, bool asc = true);

        Task<T> AddAsync(T model);

        Task<bool> DeleteAsync(T model);

        Task<bool> DeleteByIdAysnc(Guid id);

        Task<bool> UpdateAsync(T model);
    }
}
