using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class VacationConfiguration : IEntityTypeConfiguration<Vacation>
    {
       
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.ToTable("vacation");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(p => p.user_id)
               .HasColumnName("userId")
               .IsRequired();
            builder.Property(p => p.initDate)
                .HasColumnName("initDate")
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.endDate)
                .HasColumnName("endDate")
                .HasColumnType("datetime")
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
                 .HasOne(e => e.client)
                 .WithMany(e => e.vacations)
                 .HasForeignKey(e => e.user_id);

            builder
                .HasKey(p => p.Id);

            
        }
    }
}