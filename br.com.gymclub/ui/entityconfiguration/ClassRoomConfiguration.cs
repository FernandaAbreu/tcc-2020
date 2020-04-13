using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class ClassRoomConfiguration : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.ToTable("class_rooom");

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
                new ClassRoom
                {
                    Id = 1,
                    Name = "Sala 1"
                },
                 new ClassRoom
                 {
                     Id = 2,
                     Name = "Sala 2"
                 },
                  new ClassRoom
                  {
                      Id = 3,
                      Name = "Sala 3"
                  },
                   new ClassRoom
                   {
                       Id = 4,
                       Name = "Sala 4"
                   },
                   new ClassRoom
                   {
                       Id = 5,
                       Name = "Sala 5"
                   }
             );
        }
    }
}