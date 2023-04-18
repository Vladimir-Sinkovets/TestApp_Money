using Microsoft.EntityFrameworkCore;
using TestApp_Money.Entites.Models;

namespace TestApp_Money.Infrastructure.Interfaces.DataAccessInterfaces
{
    public interface IDbContext
    {
        DbSet<Record> Records { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<User> Users { get; set; }

        void SaveChanges();
        Task SaveChangesAsync(CancellationToken token);
    }
}