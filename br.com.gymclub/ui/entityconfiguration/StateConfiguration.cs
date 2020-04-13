using System;
using api.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("state");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(150)
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
                new State
                {
                    Id = 1,
                    Name = "Acre"
                },
                 new State
                 {
                     Id = 2,
                     Name = "Alagoas"
                 },
                 new State
                 {
                     Id = 3,
                     Name = "Amazonas"

                 },
                 new State
                 {
                     Id = 4,
                     Name = "Amapá"

                 },
                 new State
                 {
                     Id = 5,
                     Name = "Bahia"
                 },
                 new State
                 {
                     Id = 6,
                     Name = "Ceará"
                 },
                 new State
                 {
                     Id = 7,
                     Name = "Distrito Federal"
                 },
                 new State
                 {
                     Id = 8,
                     Name = "Espírito Santo"
                 },
                 new State
                 {
                     Id = 9,
                     Name = "Goiás"
                 },
                 new State
                 {
                     Id = 10,
                     Name = "Maranhão"
                 },
                 new State
                 {
                     Id = 11,
                     Name = "Minas Gerais"
                 },
                 new State
                 {
                     Id = 12,
                     Name = "Mato Grosso do Sul"
                 },
                 new State
                 {
                     Id = 13,
                     Name = "Mato Grosso"
                 },
                 new State
                 {
                     Id = 14,
                     Name = "Pará"
                 },
                 new State
                 {
                     Id = 15,
                     Name = "Paraíba"
                 },
                 new State
                 {
                     Id = 16,
                     Name = "Pernambuco"
                 },
                 new State
                 {
                     Id = 17,
                     Name = "Piauí"
                 },
                 new State
                 {
                     Id = 18,
                     Name = "Paraná"
                 },
                 new State
                 {
                     Id = 19,
                     Name = "Rio de Janeiro"
                 },
                 new State
                 {
                     Id = 20,
                     Name = "Rio Grande do Norte"
                 },
                 new State
                 {
                     Id = 21,
                     Name = "Rondônia"
                 },
                 new State
                 {
                     Id = 22,
                     Name = "Roraima"
                 },
                 new State
                 {
                     Id = 23,
                     Name = "Rio Grande do Sul"
                 },
                 new State
                 {
                     Id = 24,
                     Name = "Santa Catarina"
                 },
                 new State
                 {
                     Id = 25,
                     Name = "Sergipe"
                 },
                 new State
                 {
                     Id = 26,
                     Name = "São Paulo"
                 },
                 new State
                 {
                     Id = 27,
                     Name = "Tocantins"
                 });
        }
    }
}