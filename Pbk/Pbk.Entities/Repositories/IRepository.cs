using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pbk.Entities.Repositories;
public interface IRepository<T>
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Remove(T entity);  
    Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<List<T>> GetListByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    IQueryable<T> GetAll();
    DbContext getContext { get; }
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    bool Any(Expression<Func<T, bool>> expression);
    int Max(Expression<Func<T, int>> expression);
}
