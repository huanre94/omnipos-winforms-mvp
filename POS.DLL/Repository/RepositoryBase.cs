using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.DLL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected POSEntities posdbContext;

        public RepositoryBase(POSEntities dbContext)
        {
            posdbContext = dbContext;
        }

        public void Create(T entity) => posdbContext.Set<T>().Add(entity);

        public void Delete(T entity) => throw new NotImplementedException(); // posdbContext.Set<T>().Update(entity);

        public void Update(T entity) => throw new NotImplementedException(); //posdbContext.Update(entity);

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? posdbContext.Set<T>().AsNoTracking() : posdbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? posdbContext.Set<T>().Where(expression).AsNoTracking() : posdbContext.Set<T>().Where(expression);
        }

    }
}
