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
                .OrderBy(_ => _.NetworkName)
                .ToListAsync();
        }

        public async Task<NetworkLogo?> CreateNetwork(NetworkLogoViewModel model)
        {
            var exists = _context.NetworkLogos
                .AsNoTracking().FirstOrDefault(_ => _.NetworkName == model.NetworkName && _.UserId == model.UserId);
            if (exists == null)
            {
                var networkLogo = new NetworkLogo();
                networkLogo.Add(model);
                var network = _context.NetworkLogos.Add(networkLogo);
                await _context.SaveChangesAsync();
                return networkLogo;

            }
            throw new ArgumentException("Bad Request, Network exists");
        }

        public async Task<NetworkLogo?> UpdateNetwork(NetworkLogoViewModel model)
        {
            var network = _context.NetworkLogos.AsNoTracking().FirstOrDefault(_ => _.Id == model.Id);
            if (network != null)
            {
                network.Update(model);
                _context.NetworkLogos.Update(network);
                await _context.SaveChangesAsync();
                return network;

            }
            return null;
        }
    }
}