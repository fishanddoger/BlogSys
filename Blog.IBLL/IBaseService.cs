using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IBLL
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> AddAsync(T model);

        Task<bool> UpdateAsync(T model);


        Task<bool> DeleteAsync(T model);

        Task<bool> DeleteByIdAsync(Guid id);

        T GetOne(Guid id);

        IQueryable<T> GetAll();

        IQueryable<T> GetList(Expression<Func<T, bool>> whereStr);
        IQueryable<T> GetAllByPage(int pageSize, int pageIndex, bool asc);

        IQueryable<T> GetListByPageWithWhere(int pageSize, int pageIndex, bool asc, Expression<Func<T, bool>> whereStr);
    }
}
