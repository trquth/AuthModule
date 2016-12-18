using Auth.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Auth.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Insert(T dto);
        IEnumerable<T> Insert(IEnumerable<T> list);
        T Update(T dto);
        bool Update(List<T> dto);
        T GetById(Guid id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T SingleBy(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetRange(int pageIndex, int pageSize);
        IEnumerable<T> GetRange(int pageIndex, int pageSize, out int count);
        IEnumerable<T> GetRange(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize);
        IEnumerable<T> GetRange(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize, out int count);
        T Delete(T dto);
    }
}
