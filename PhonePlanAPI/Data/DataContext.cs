using Microsoft.EntityFrameworkCore;
using PhonePlanAPI.Models;

namespace PhonePlanAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PhonePlan> PhonePlans { get; set; }
        public DbSet<PlanType> PlanTypes { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<DDD> DDDs { get; set; }
        public DbSet<PlanDDD> PlanDDDs { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DDD>().HasData(
                new DDD { Id = 011 },
                new DDD { Id = 022 },
                new DDD { Id = 041 },
                new DDD { Id = 048 },
                new DDD { Id = 047 }
                );

            modelBuilder.Entity<Operator>().HasData(
                new Operator { Id = 1, Name = "Tim" },
                new Operator { Id = 2, Name = "Claro" },
                new Operator { Id = 3, Name = "Vivo" }
                );

            modelBuilder.Entity<PlanType>().HasData(
                new PlanType { Id = 1, Name = "Controle" },
                new PlanType { Id = 2, Name = "Pré" },
                new PlanType { Id = 3, Name = "Pós" }
                );

            modelBuilder.Entity<PhonePlan>().HasData(
                new PhonePlan { Id = 1, Internet = 500, Minutes = 50, IdOperator = 1, IdPlanType = 1, Value = 47.5m }
                );

            modelBuilder.Entity<PlanDDD>().HasData(
               new PlanDDD { Id = 1, IdDDD = 11, IdPhonePlan = 1 },
               new PlanDDD { Id = 2, IdDDD = 41, IdPhonePlan = 1 },
               new PlanDDD { Id = 3, IdDDD = 48, IdPhonePlan = 1 }
               );
        }
    }
}