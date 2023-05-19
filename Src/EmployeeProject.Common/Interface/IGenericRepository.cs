using System.Linq.Expressions;
using EmployeeProject.Common.Model;

namespace EmployeeProject.Common.Interface;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params Expression<Func<T, object>>[] includes);
    Task<List<T>> GetAsync(int? skip, int? take,params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
    Task<Guid> InsertAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}