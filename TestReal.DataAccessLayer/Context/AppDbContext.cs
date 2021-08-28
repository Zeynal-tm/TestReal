using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestReal.Persistence.Domain;

namespace TestReal.Persistence.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<UserRegistration> UserRegistration { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        
        async Task IAppDbContext.AddAsync<T>(T entity, CancellationToken cancellationToken)
        {
            await base.AddAsync(entity, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}