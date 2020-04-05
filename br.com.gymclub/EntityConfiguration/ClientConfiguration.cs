using System;
using domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {

       
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.Property(p => p.IdRegistration)
                .HasColumnName("idRegistration")
                .IsRequired();

            builder.Property(p => p.Street)
                .HasColumnName("street")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(p => p.Neighborhood)
               .HasColumnName("neighborhood")
               .HasMaxLength(150)
               .IsRequired();


            builder.Property(p => p.idCity)
              .HasColumnName("idCity")
              .IsRequired();

            builder.Property(p => p.idState)
              .HasColumnName("idState")
              .IsRequired();
            
                builder.Property(p => p.ContractStartDate)
               .HasColumnName("ContractStartDate")
               .HasColumnType("datetime")
               .IsRequired(true);
            builder.Property(p => p.ContractEndDate)
               .HasColumnName("ContractEndDate")
               .HasColumnType("datetime")
               .IsRequired(false);

            builder.Property(p => p.idPlanType)
            .HasColumnName("idPlanType")
            .IsRequired();

            builder.Property(p => p.idTypePayment)
           .HasColumnName("idTypePayment")
           .IsRequired();

            builder.Property(p => p.idUser)
          .HasColumnName("idUser")
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
                .HasOne(e => e.state)
                .WithMany(e => e.clients)
                .HasForeignKey(e => e.idState);

            builder
               .HasOne(e => e.city)
               .WithMany(e => e.clients)
               .HasForeignKey(e => e.idCity);

            builder
               .HasOne(e => e.planType)
               .WithMany(e => e.clients)
               .HasForeignKey(e => e.idCity);
            builder
               .HasOne(e => e.typePayment)
               .WithMany(e => e.clients)
               .HasForeignKey(e => e.idTypePayment);


            builder
                .HasKey(p => p.IdRegistration);


        }
    }
}