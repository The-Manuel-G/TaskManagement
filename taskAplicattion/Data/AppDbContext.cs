using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para las entidades
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        // Configuración del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de nombres de tablas
            modelBuilder.Entity<TaskItem>().ToTable("Task");
            modelBuilder.Entity<Status>().ToTable("Status");

            // Configuración de la entidad Status
            modelBuilder.Entity<Status>()
                .HasKey(s => s.StatusId);

            modelBuilder.Entity<Status>()
                .Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            // Relación uno a muchos con TaskItem
            modelBuilder.Entity<Status>()
                .HasMany(s => s.TaskItems)
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la entidad TaskItem
            modelBuilder.Entity<TaskItem>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Description)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.DueDate)
                .IsRequired();

            // Datos iniciales (Seed Data) para Status
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, Name = "Pending" },
                new Status { StatusId = 2, Name = "In Progress" },
                new Status { StatusId = 3, Name = "Completed" }
            );
        }
    }
}