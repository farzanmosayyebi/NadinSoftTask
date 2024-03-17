using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Core.Interfaces;

public interface IGenericRepository<T> where T : EntityBase
{
    Task<int> CreateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> ListAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes);
    Task<List<T>> ListAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params Expression<Func<T, object>>[] includes);
    Task UpdateAsync(T entity);
    Task Delete(int id);
    Task SaveChangesAsync();
}
