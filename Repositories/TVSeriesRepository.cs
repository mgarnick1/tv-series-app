using System;
using AutoMapper;
using System.Text.Json;
using tv_series_app.Models;
using tv_series_app.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using RestSharp;

namespace tv_series_app.Repositories
{
    public class TVSeriesRepository : ITVSeriesRepository
    {
        private DataContext _context;
        private AutoMapper.IConfigurationProvider _config;
        public readonly IMapper _mapper;

        public TVSeriesRepository(DataContext context, IMapper mapper, AutoMapper.IConfigurationProvider config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;


        }

        public async Task<TVSeries> AddTVSeries(TVSeriesViewModel tvSeries)
        {
            var exists = _context.TVSeries.FirstOrDefault(_ => _.Name == tvSeries.Name && _.User.Id == tvSeries.UserId);
            if (exists == null)
            {

                var series = new TVSeries();
                series.Add(tvSeries);
                var show = _context.TVSeries.Add(series);
                await _context.SaveChangesAsync();
                return series;
            }
            throw new ArgumentException("Bad Request, TVSeries exists");
        }

        public async Task<TVSeries?> EditTVSeries(TVSeriesViewModel tvSeries)
        {
            var series = await _context.TVSeries
                .AsNoTracking().FirstOrDefaultAsync(_ => _.Id == tvSeries.Id);
            if (series != null)
            {

                series.Update(tvSeries);
                _context.TVSeries.Update(series);
                await _context.SaveChangesAsync();
                return series;
            }
            return null;
        }

        public async Task<TVSeries?> GetTVSeries(int id)
        {
            return await _context.TVSeries.FindAsync(id);
        }

        public async Task<List<TVSeriesViewModel>> GetAllTVSeriesByUserId(string userId)
        {
            return await _context.TVSeries
                .AsNoTracking()
                .ProjectTo<TVSeriesViewModel>(_config)
                .Where(_ => _.UserId == userId)
                .ToListAsync();

        }

        public async Task<List<TVSeriesViewModel>> GetEpisodeDateRecommendations(int page)
        {
            RestClient client = new RestClient("https://www.episodate.com/api");
            RestRequest request = new RestRequest("most-popular");
            request.AddParameter("page", page);

            var response = await client.GetAsync<EpisodeDateViewModel>(request);
            
            var showsList = response?.tv_shows;

            List<TVSeriesViewModel> recommendations = new List<TVSeriesViewModel>() { };
            if (response != null && showsList.Count() > 0)
            {
                foreach(var show in showsList)
                {
                   var tvSeries = _mapper.Map<TVSeriesViewModel>(show);
                   recommendations.Add(tvSeries);
                }
            }
            return recommendations;


        }
    }
}