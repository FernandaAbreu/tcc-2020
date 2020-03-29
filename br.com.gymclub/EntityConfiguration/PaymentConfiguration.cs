using System;
using domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{

   
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");

            builder.Property(p => p.idRegistration)
                .HasColumnName("idRegistration")
                .IsRequired();
            builder.Property(p => p.idTypePlan)
             .HasColumnName("idTypePlan")
             .IsRequired();

            builder.Property(p => p.idTypePayment)
             .HasColumnName("idTypePayment")
             .IsRequired();
            builder.Property(p => p.PaymentDay)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DueDate)
               .HasColumnName("DueDate")
               .HasColumnType("datetime")
               .IsRequired(false);
            
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
                .WithMany(e => e.payments)
                .HasForeignKey(e => e.idRegistration);
            builder
               .HasOne(e => e.TypePayment)
               .WithMany(e => e.payments)
               .HasForeignKey(e => e.idTypePayment);
            builder
               .HasOne(e => e.planType)
               .WithMany(e => e.payments)
               .HasForeignKey(e => e.idTypePlan);

            builder
                .HasKey(p => p.Id);


        }
    }
}