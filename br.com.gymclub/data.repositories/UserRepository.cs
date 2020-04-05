﻿using System;
using System.Collections.Generic;
using System.Linq;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;
using Microsoft.EntityFrameworkCore;

namespace data.repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public User FindByEmail(string email)
        {
            return mcontexto.User
                 .Include(p => p.UserType)
                 .Where(u => u.Email == email)
                 .SingleOrDefault();
        }

        public User FindById(int id)
        {
            return mcontexto.User
                 .Include(p => p.UserType)
                 .Where(u => u.Id == id)
                 .SingleOrDefault();
        }


    }
}