using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp_Money.Entites.Models;
using TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces;

namespace TestApp_Money.DataAccess.MsSql
{
    public class ApplicationDbContext : IdentityDbContext<User>, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Record> Records { get; set; }
        public DbSet<Category> Categories { get; set; }

        void IDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        async Task IDbContext.SaveChangesAsync(CancellationToken token)
        {
            await base.SaveChangesAsync(token);
        }
    }
}
