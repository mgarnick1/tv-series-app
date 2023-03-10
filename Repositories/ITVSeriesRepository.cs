using System;
using tv_series_app.Models;
using tv_series_app.ViewModels;

namespace tv_series_app.Repositories
{
    public interface ITVSeriesRepository
    {
        Task<TVSeries> AddTVSeries(TVSeriesViewModel tvSeries);
        Task<TVSeries?> EditTVSeries(TVSeriesViewModel tvSeries);
        Task<TVSeries?> GetTVSeries(int id);
        Task<List<TVSeriesViewModel>> GetAllTVSeriesByUserId(string userId);
        Task<List<TVSeriesViewModel>> GetEpisodeDateRecommendations(int page, string userId);
        
    }
}