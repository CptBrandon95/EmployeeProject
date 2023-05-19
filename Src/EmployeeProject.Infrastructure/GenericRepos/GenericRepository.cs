using System.Linq.Expressions;
using EmployeeProject.Common.Interface;
using EmployeeProject.Common.Model;
using EmployeeProject.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Infrastructure.GenericRepos;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private ApplicationDbContext DbContext { get; }
    private DbSet<T> DbSet { get; }
    /*
     * We are working with the database
     * so we need to inject the db context in the repo class
     */
    public GenericRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<T>();
    }
    public async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> queryable = DbSet;

        foreach (var filter in filters)
            queryable = queryable.Where(filter);
            

        if (skip != null)
            queryable = queryable.Skip(skip.Value);
        if (take != null)
            queryable = queryable.Take(take.Value);

        return await queryable.ToListAsync();

    }

    public async Task<List<T>> GetAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> queryable = DbSet;

        foreach (var include in includes)
            queryable = queryable.Include(include);

        if (skip != null)
            queryable = queryable.Skip(skip.Value);
        if (take != null)
            queryable = queryable.Take(take.Value);
        return await queryable.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = DbSet;
        query = query.Where(e => e.Id == id);

        foreach (var include in includes)
            query = query.Include(include);
        
        return await query.SingleOrDefaultAsync();
    }

    public async Task<Guid> InsertAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity.Id;
    }

    public void Update(T entity)
    {
        DbSet.Attach(entity);
        DbSet.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        if (DbContext.Entry(entity).State == EntityState.Detached)
            DbSet.Attach(entity);
        DbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await DbContext.SaveChangesAsync();
    }
}