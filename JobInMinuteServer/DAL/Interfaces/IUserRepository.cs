﻿using JobInMinuteServer.Models;

namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);
        Task SaveUser(User user);
    }
}