using System;
using tv_series_app.Models;
using tv_series_app.ViewModels;

namespace tv_series_app.Repositories
{
    public interface INetworkLogoRepository
    {
        public Task<List<NetworkLogoViewModel>> GetUserNetworkLogos(string userId);
        public Task<NetworkLogo?> CreateNetwork(NetworkLogoViewModel model);
        public Task<NetworkLogo?> UpdateNetwork(NetworkLogoViewModel model);
    }
}