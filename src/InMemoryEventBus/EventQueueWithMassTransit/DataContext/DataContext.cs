using Microsoft.EntityFrameworkCore;

namespace EventQueueWithMassTransit.DataContext
{
    public class DataContext: DbContext
    {
        public DataContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-HF8RPF0\\SQLEXPRESS;Database=Tesuto;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<TestRun> TestRuns { get; set; }
    }
}
