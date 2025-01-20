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
        public DbSet<TaskItem<object>> TaskItems { get; set; }

        // Configuración del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llama al método base para las configuraciones predeterminadas
            base.OnModelCreating(modelBuilder);

            // Configuración de nombres de tablas
            modelBuilder.Entity<TaskItem<object>>().ToTable("Task");
            modelBuilder.Entity<Status>().ToTable("Status");

            // Configuración de la entidad Status
            modelBuilder.Entity<Status>()
                .HasKey(s => s.StatusId); // Llave primaria

            modelBuilder.Entity<Status>()
                .Property(s => s.Name)
                .HasMaxLength(50) // Longitud máxima de 50 caracteres
                .IsRequired(); // Campo obligatorio

            modelBuilder.Entity<Status>()
                .HasMany(s => s.TaskItems) // Relación uno a muchos
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Cascade); // Eliminación en cascada

            // Configuración de la entidad TaskItem
            modelBuilder.Entity<TaskItem<object>>()
                .HasKey(t => t.Id); // Llave primaria

            modelBuilder.Entity<TaskItem<object>>()
                .Property(t => t.Name)
                .HasMaxLength(100) // Longitud máxima de 100 caracteres
                .IsRequired(); // Campo obligatorio

            modelBuilder.Entity<TaskItem<object>>()
                .Property(t => t.Description)
                .HasMaxLength(300) // Longitud máxima de 300 caracteres
                .IsRequired(); // Campo obligatorio

            modelBuilder.Entity<TaskItem<object>>()
                .Property(t => t.DueDate)
                .IsRequired(); // Campo obligatorio

            // Datos iniciales (Seed Data) para Status
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, Name = "Pending" },
                new Status { StatusId = 2, Name = "In Progress" },
                new Status { StatusId = 3, Name = "Completed" }
            );
        }
    }
}
