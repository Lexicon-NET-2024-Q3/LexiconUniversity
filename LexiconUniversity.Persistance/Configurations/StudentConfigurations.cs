using LexiconUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUniversity.Persistance.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.OwnsOne(s => s.Name)
              .Property(n => n.FirstName)
              .HasColumnName("FirstName");
            builder.OwnsOne(s => s.Name)
                .Property(n => n.LastName)
                .HasColumnName("LastName");

            builder.Property<DateTime>("Edited"); 

            builder.HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Enrollment>(
                e => e.HasOne(e => e.Course).WithMany(c => c.Enrollments),
                e => e.HasOne(e => e.Student).WithMany(s => s.Enrollments),
                e => e.HasKey(e => new { e.CourseId, e.StudentId }));
        }
    }
}
