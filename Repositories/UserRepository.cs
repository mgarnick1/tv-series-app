using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tv_series_app.Models;
using tv_series_app.Repositories;
using tv_series_app.ViewModels;

namespace tv_series_app.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        private readonly UserManager<User> _userManager;
        private AutoMapper.IConfigurationProvider _config;
        public readonly IMapper _mapper;

        private readonly ITVSeriesRepository _tvRepository;

        public UserRepository(DataContext context, UserManager<User> userManager, AutoMapper.IConfigurationProvider config, IMapper mapper, ITVSeriesRepository tvRepository)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
            _mapper = mapper;
            _tvRepository = tvRepository;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserTVSeriesModel> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var tvSeries = await _tvRepository.GetAllTVSeriesByUserId(userId);
                user.TVSeries = _mapper.Map<List<TVSeries>>(tvSeries);
                return _mapper.Map<UserTVSeriesModel>(user);

            }
            throw new ArgumentException("User not found");
        }
    }
}