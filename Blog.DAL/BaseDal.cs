using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public class BaseDal<T> where T:BaseEntity
    {
        public BlogDbContext dbContext = new BlogDbContext();

        public IQueryable<T> GetAllEntities()
        {
            return dbContext.Set<T>().Where(e => !e.IsDelete);
        }

        public T GetOne(Guid id)
        {
            return GetAllEntities().First(e => e.Id == id);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereStr)
        {
            return GetAllEntities().Where(whereStr);
        }

        public IQueryable<T> GetEntitiesByPage(int pageSize, int pageIndex, bool asc = true)
        {
            if (asc)
            {
                return GetAllEntities().Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return GetAllEntities().OrderByDescending(e => e.CreateTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }
        }

        public async Task<T> AddAsync(T model)
        {
            dbContext.Set<T>().Add(model);
            int count= await dbContext.SaveChangesAsync();

            return count > 0 ? model : null;
        }

        public async Task<bool> DeleteAsync(T model)
        {
            dbContext.Entry<T>(model).State = EntityState.Deleted;

            return (await dbContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteByIdAysnc(Guid id)
        {
            T model = GetOne(id);

            if (model!=null)
            {
                return await DeleteAsync(model);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T model)
        {
            dbContext.Entry<T>(model).State = EntityState.Modified;

            return (await dbContext.SaveChangesAsync()) > 0;
        }

        public IQueryable<T> GetEntitiesByPageWithWhere(int pageSize, int pageIndex, Expression<Func<T, bool>> whereStr, bool asc = true) 
        {
            if (asc)
            {
                return GetList(whereStr).OrderBy(e=>e.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return GetList(whereStr).OrderByDescending(e=>e.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
    }
}
