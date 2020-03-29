﻿using System;
namespace domain.models
{
    public class User
    {
        public User()
        {
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
        public Physiotherapist physiotherapist { get; set; }
        public Instructor instructor { get; set; }

    }
}