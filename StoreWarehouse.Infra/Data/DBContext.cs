using Microsoft.EntityFrameworkCore;
using StoreWarehouse.Domain.Entities;

namespace StoreWarehouse.Infra.Data
{
    internal class DBContext : DbContext
    {
        public DbSet<ProductTrack> ProductTrack { get; set; }
        public DBContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }
    }
}
