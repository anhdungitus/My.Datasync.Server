using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace My.Datasync.Server.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// The dataset for the TodoItems.
        /// </summary>
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
        public DbSet<TodoItemList> TodoItemLists => Set<TodoItemList>();
        public DbSet<AllTodoItems> AllTodoItems { get;set; }
        public DbSet<qCost> QuoteLines { get;set; }

        /// <summary>
        /// Do any database initialization required.
        /// </summary>
        /// <returns>A task that completes when the database is initialized</returns>
        public async Task InitializeDatabaseAsync()
        {
            
            await this.Database.EnsureCreatedAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TodoItem>().Navigation(e => e.Items).AutoInclude();
            //modelBuilder.Entity<AllTodoItems>().Navigation(e => e.Items).AutoInclude();
            modelBuilder.Entity<AllTodoItems>().Navigation(e => e.QuoteLines).AutoInclude();
            modelBuilder.Entity<AllTodoItems>().HasMany(e => e.QuoteLines).WithOne()
                .HasForeignKey(e => e.TodoItemAutoId)
                .HasPrincipalKey(u => u.AutoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}