using CrudSqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSqlServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opcines) : base(opcines)
        {

        }
        public DbSet<Registro> Registros { get; set; }
    }
}
