using System;
using domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("lesson");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
               .HasColumnName("description")
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(p => p.InitialHour)
               .HasColumnName("startHour")
               .HasColumnType("time")
               .IsRequired(true);


            builder.Property(p => p.EndHour)
             .HasColumnName("endHour")
             .HasColumnType("time")
             .IsRequired(true);

            builder.Property(p => p.idTypeClass)
              .HasColumnName("idTypeClass")
              .IsRequired();

            builder.Property(p => p.idDaysWeek)
             .HasColumnName("idDaysWeek")
             .IsRequired();

            builder.Property(p => p.idClassRoom)
             .HasColumnName("idClassRoom")
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
                .HasOne(e => e.classType)
                .WithMany(e => e.lessons)
                .HasForeignKey(e => e.idTypeClass);

            builder
                .HasOne(e => e.daysWeek)
                .WithMany(e => e.lessons)
                .HasForeignKey(e => e.idDaysWeek);

            builder
                .HasOne(e => e.classRoom)
                .WithMany(e => e.lessons)
                .HasForeignKey(e => e.idClassRoom);

            builder
                .HasKey(p => p.Id);


        }
    }
}