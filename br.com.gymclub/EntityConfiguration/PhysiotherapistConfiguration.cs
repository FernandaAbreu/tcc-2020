using System;
using domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class PhysiotherapistConfiguration : IEntityTypeConfiguration<Physiotherapist>
    {
        public void Configure(EntityTypeBuilder<Physiotherapist> builder)
        {
            builder.ToTable("physiotherapist");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(p => p.userId)
               .HasColumnName("userId")
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
                .HasOne(e => e.User)
                .WithMany(e => e.physiotherapist)
                .HasForeignKey(e => e.userId);

        }
    }
}