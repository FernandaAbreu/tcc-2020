﻿using System;
namespace services.Interfaces
{
    public interface IUserService
    {
        User Create(User user, int advertiserId);
        User FindByEmail(string email);
        bool IsAdmin(int id);
    }
}
