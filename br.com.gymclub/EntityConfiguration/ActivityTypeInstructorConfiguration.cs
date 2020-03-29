using System;
using domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class ActivityTypeInstructorConfiguration : IEntityTypeConfiguration<ActivityTypeInstructor>
    {
        public void Configure(EntityTypeBuilder<ActivityTypeInstructor> builder)
        {
            builder.ToTable("activity_type_instructor");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();


            builder.Property(p => p.idTypeActivity)
              .HasColumnName("idTypeActivity")
              .IsRequired();
            builder.Property(p => p.idInstructor)
              .HasColumnName("idInstructor")
              .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.DeletedAt)
                .HasColumnName("deletedAt")
                .HasColumnType("datetime")
                .IsRequired(false);

            builder
                .HasKey(p => p.Id);

            builder
           .HasOne(e => e.typeActivity)
           .WithMany(e => e.activityTypeInstructors)
           .HasForeignKey(e => e.idTypeActivity);


            builder
          .HasOne(e => e.instructor)
          .WithMany(e => e.activityTypeInstructors)
          .HasForeignKey(e => e.idInstructor);


        }
    }
}