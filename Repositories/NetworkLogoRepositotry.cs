using System;
using AutoMapper;
using tv_series_app.Models;
using tv_series_app.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace tv_series_app.Repositories
{
    public class NetworkLogoRepository : INetworkLogoRepository
    {
        private DataContext _context;
        private AutoMapper.IConfigurationProvider _config;
        public readonly IMapper _mapper;

        public NetworkLogoRepository(DataContext context, IMapper mapper, AutoMapper.IConfigurationProvider config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        public async Task<List<NetworkLogoViewModel>> GetUserNetworkLogos(string userId)
        {
            return await _context.NetworkLogos
                .AsNoTracking()
                .ProjectTo<NetworkLogoViewModel>(_config)
                .Where(_ => _.UserId == userId)
                .ToListAsync();
        }
    }
}