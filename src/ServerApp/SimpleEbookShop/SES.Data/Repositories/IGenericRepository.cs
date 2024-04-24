using SES.Domain.Entities.Base;

namespace SES.Data.Repositories;

public interface IGenericRepository<TEntity> : IDisposable
    where TEntity : IEntity
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<TEntity> InsertAsync(TEntity item, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
    Task<TEntity> InsertOrUpdateAsync(TEntity item, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}