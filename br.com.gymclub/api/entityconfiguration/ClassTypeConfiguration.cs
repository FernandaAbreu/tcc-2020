using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class ClassTypeConfiguration : IEntityTypeConfiguration<ClassType>
    {
        public void Configure(EntityTypeBuilder<ClassType> builder)
        {
            builder.ToTable("class_type");

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
              .HasData(
                 new ClassType
                 {
                     Id = 1,
                     Name = "Aerobica",

                 },
               new ClassType
               {
                   Id = 2,
                   Name = "Individuais",

               },
               new ClassType
               {
                   Id = 3,
                   Name = "Localizadas",

               },
               new ClassType
               {
                   Id = 4,
                   Name = "Lutas",

               },
               new ClassType
               {
                   Id = 5,
                   Name = "Esportes",

               }
                  );
        }
    }
}