﻿using System;
using api.models;
using helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
        }
        private readonly IPasswordManager _passwordManager;

        public UserConfiguration(IPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Token { get; set; }
        public UserType UserType { get; set; }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnName("password")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Rg)
                 .HasColumnName("rg")
                 .HasMaxLength(15)
                 .IsRequired();
            builder.Property(p => p.Cpf)
                .HasColumnName("cpf")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.UserTypeId)
                .HasColumnName("userTypeId")
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
                .Ignore(p => p.Token);

            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(e => e.UserType)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.UserTypeId);

            builder
                .HasData(
                    new User
                    {
                        Id = 1,
                        Name = "GymClub",
                        Email = "admin@gymglub.com",
                        Password = _passwordManager.HashPassword("GymclubSenha"),
                        Rg= "17.979.066-3",
                        Cpf= "288.789.134-05",
                        UserTypeId = 1
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Fernanda Abreu",
                        Email = "fefetwsp@hotmail.com",
                        Password = _passwordManager.HashPassword("GymclubSenha"),
                        Rg = "29.003.656-2",
                        Cpf = "037.467.048-04",
                        UserTypeId = 5
                    },
                    new User
                    {
                        Id = 3,
                        Name = "Instrutor  teste",
                        Email = "instrutor1@gymglub.com",
                        Password = _passwordManager.HashPassword("GymclubSenha"),
                        Rg = "16.224.837-4",
                        Cpf = "276.267.434-40",
                        UserTypeId = 3
                    },
                    new User
                    {
                        Id = 4,
                        Name = "Recepcionista  teste",
                        Email = "recepcionista1@gymglub.com",
                        Password = _passwordManager.HashPassword("GymclubSenha"),
                        Rg = "37.088.796-7",
                        Cpf = "897.552.694-10",
                        UserTypeId = 2
                    },
                    new User
                    {
                        Id = 5,
                        Name = "Usuário 2",
                        Email = "user2@hotmail.com",
                        Password = _passwordManager.HashPassword("GymclubSenha"),
                        Rg = "42.970.977-8",
                        Cpf = "802.671.886-09",
                        UserTypeId = 5
                    }
                );
        }

    }
}
