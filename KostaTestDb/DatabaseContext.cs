using Microsoft.EntityFrameworkCore;

namespace KostaTestDb
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Property(d => d.Code).HasMaxLength(10);
            modelBuilder.Entity<Department>().Property(e => e.Name).HasMaxLength(50);

            modelBuilder.Entity<Employee>().Property(e => e.ID).ValueGeneratedOnAdd().HasColumnType("numeric(5, 0)");
            modelBuilder.Entity<Employee>().Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.SurName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Patronymic).HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(e => e.DocSeries).HasMaxLength(4);
            modelBuilder.Entity<Employee>().Property(e => e.DocNumber).HasMaxLength(6);
            modelBuilder.Entity<Employee>().Property(e => e.DateOfBirth).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Position).IsRequired();
        }
    }
}

