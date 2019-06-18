using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OZBAY.Core.Entities;

namespace OZBAY.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

    }
}
