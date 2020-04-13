using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
      
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("evaluation");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.anamnese)
                .HasColumnName("anamnese")
                .IsRequired();
            builder.Property(p => p.skinFolds)
                .HasColumnName("skinFolds")
                .IsRequired();

            builder.Property(p => p.ergometric)
               .HasColumnName("ergometric")
               .IsRequired();

            builder.Property(p => p.idRegistration)
               .HasColumnName("idRegistration")
               .IsRequired();
            builder.Property(p => p.idPhysiotherapist)
               .HasColumnName("idPhysiotherapist")
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
                .WithMany(e => e.evaluations)
                .HasForeignKey(e => e.idRegistration);
            builder
               .HasOne(e => e.physiotherapist)
               .WithMany(e => e.evaluations)
               .HasForeignKey(e => e.idPhysiotherapist);


        }
    }
}