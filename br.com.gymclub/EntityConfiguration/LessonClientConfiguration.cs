using System;
using domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class LeessonClientConfiguration : IEntityTypeConfiguration<LessonsClient>
    {
        public void Configure(EntityTypeBuilder<LessonsClient> builder)
        {
            builder.ToTable("lesson_client");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.idLesson)
              .HasColumnName("idLesson")
              .IsRequired();
            builder.Property(p => p.idRegistration)
              .HasColumnName("idRegistration")
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
             .HasOne(e => e.client)
             .WithMany(e => e.lessonsClients)
             .HasForeignKey(e => e.idRegistration);

            builder
            .HasOne(e => e.lesson)
            .WithMany(e => e.lessonsClients)
            .HasForeignKey(e => e.idLesson);

        }
    }
}