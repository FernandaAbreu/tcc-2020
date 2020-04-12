using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class DaysWeekConfiguration : IEntityTypeConfiguration<DaysWeek>
    {
        public void Configure(EntityTypeBuilder<DaysWeek> builder)
        {
            builder.ToTable("days_week");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(20)
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
               .HasData(
                   new DaysWeek
                   {
                       Id = 1,
                       Name = "domingo"
                       
                   },
                   new DaysWeek
                   {
                       Id = 2,
                       Name = "segunda-feira"

                   },
                   new DaysWeek
                   {
                       Id = 3,
                       Name = "terça-feira"

                   },
                   new DaysWeek
                   {
                       Id = 4,
                       Name = "quarta-feira"

                   },
                   new DaysWeek
                   {
                       Id = 5,
                       Name = "quinta-feira"

                   },
                   new DaysWeek
                   {
                       Id = 6,
                       Name = "sexta-feira"

                   },
                   new DaysWeek
                   {
                       Id = 7,
                       Name = "sábado"

                   }
               );

        }
    }
}