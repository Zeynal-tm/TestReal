using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TestReal.Persistence
{
    public interface IAppDbContext
    {
        DbSet<T> Set<T>() where T : class;
        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}