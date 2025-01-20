using Microsoft.EntityFrameworkCore;

namespace DB

{
    public class TaskContex : DbContext
    {

        public TaskContex(DbContextOptions<TaskContex> options)
            : base(options) { }

        public DbSet<Status> statuss { get; set; }
        public DbSet<Task> tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>().ToTable("Task");
            modelBuilder.Entity<Status>().ToTable("Status");


        }
    }
}
