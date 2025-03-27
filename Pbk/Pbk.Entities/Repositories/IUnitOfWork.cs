using Microsoft.EntityFrameworkCore.Storage;

namespace Pbk.Entities.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //IDbContextTransaction BeginTransaction();
    //Task<IDbContextTransaction> BeginTransactionAsync();
}