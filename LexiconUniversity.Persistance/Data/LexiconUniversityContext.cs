using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LexiconUniversity.Core.Entities;
using LexiconUniversity.Persistance.Configurations;

namespace LexiconUniversity.Persistance.Data
{
    public class LexiconUniversityContext : DbContext
    {
        public LexiconUniversityContext(DbContextOptions<LexiconUniversityContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; 
        }

        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<Course> Course { get; set; } = default!;
        //Not needed for Convention 2
        //public DbSet<Enrollment> Enrollments { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfigurations());

            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    entity.AddProperty("Edited", typeof(DateTime)); 
            //}
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<Student>().Where(e=>e.State == EntityState.Modified))
            {
                entry.Property("Edited").CurrentValue = DateTime.Now;
            }


            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
