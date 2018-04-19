using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.RawModels;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace DataAccessLayer
{
    public sealed class EntityDbContext: DbContext
    {
        private readonly SqliteConnectionStringBuilder _connectionString;
        
        public Microsoft.EntityFrameworkCore.DbSet<RawPdfInfo> RawPdfInfos { get; set; }

        /// <summary>
        /// Constructor that will be called by startup.cs
        /// </summary>
        /// <param name="dbContextOptionsBuilder"></param>
        /// <param name="connectionString"></param>
        public EntityDbContext(DbContextOptionsBuilder dbContextOptionsBuilder, SqliteConnectionStringBuilder connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString.ToString());
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership)
                .ToList()
                .ForEach(x => x.DeleteBehavior = DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}