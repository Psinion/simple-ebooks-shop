using Microsoft.EntityFrameworkCore;
using SES.Data.Access.EF.Contexts;
using SES.Data.Repositories;
using SES.Domain.Entities.Base;

namespace SES.Data.Access.EF.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> 
    where TEntity : class, IEntity, new()
{
    protected readonly MainDbContext LocalContext;
    protected readonly DbSet<TEntity> LocalSet;

    public GenericRepository(MainDbContext dbLocalContext) {
        LocalContext = dbLocalContext;
        LocalSet = dbLocalContext.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) 
        => await LocalSet.ToListAsync(cancellationToken);

    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => await LocalSet.FindAsync(new object[] { id }, cancellationToken);

    public virtual async Task<TEntity> InsertAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        await LocalContext.AddAsync(item, cancellationToken);
        await LocalContext.SaveChangesAsync(cancellationToken);

        return item;
    }

    public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        LocalContext.Entry(item).State = item.Id == 0 
            ? EntityState.Added : EntityState.Modified;

        await LocalContext.SaveChangesAsync(cancellationToken);

        return item;
    }

    public virtual async Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        LocalContext.Update(item);
        await LocalContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        LocalContext.Remove(new TEntity { Id = id });
        await LocalContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        LocalContext.Dispose();
    }
}