using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using ALTPOINT_CRUD.Domain.Entities;

namespace ALTPOINT_CRUD.Infrastructure.EntityFramework.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DataBaseContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqliteConn = new SqliteConnection(@"DataSource = ../altpoint-crud.infrastructure/entityframework/database/alpoint-crud.db");
            optionsBuilder.UseSqlite(sqliteConn);
        }
    }
}
