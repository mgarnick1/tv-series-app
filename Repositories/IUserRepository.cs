using System;
using tv_series_app.Models;

namespace tv_series_app.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}