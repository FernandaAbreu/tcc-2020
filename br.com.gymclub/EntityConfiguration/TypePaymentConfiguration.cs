using System;
using domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class TypePaymentConfiguration : IEntityTypeConfiguration<TypePayment>
    {
        public void Configure(EntityTypeBuilder<TypePayment> builder)
        {
            builder.ToTable("type_payment");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
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
                .HasData(new TypePayment
                {
                    Id=1,
                    Name="Débito em conta",

                },
                new TypePayment
                {
                    Id = 2,
                    Name = "Crédito",

                },
                new TypePayment
                {
                    Id = 3,
                    Name = "Boleto",

                }
                );
        }
    }
}