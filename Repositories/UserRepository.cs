using System;
using Microsoft.EntityFrameworkCore;
using tv_series_app.Models;
using tv_series_app.Repositories;

namespace tv_series_app.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}