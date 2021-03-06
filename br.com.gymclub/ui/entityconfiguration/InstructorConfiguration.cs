﻿using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("instructor");

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
                .WithMany(e => e.instructor)
                .HasForeignKey(e => e.userId);
            builder
               .HasOne(e => e.state)
               .WithMany(e => e.instructors)
               .HasForeignKey(e => e.idState);

            builder
               .HasOne(e => e.city)
               .WithMany(e => e.instructors)
               .HasForeignKey(e => e.idCity);

            builder
               .HasData(
                   new Instructor
                   {
                       Id = 1,
                       Name="Instructor teste",
                       Street = "Rua teste",
                       Neighborhood = "Teste  bairro",
                       idCity = 5270,
                       idState = 26,
                       userId = 3




                   });
        }
    }
}