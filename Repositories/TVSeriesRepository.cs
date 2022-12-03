using System;
using AutoMapper;
using tv_series_app.Models;
using tv_series_app.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace tv_series_app.Repositories
{
    public class TVSeriesRepository : ITVSeriesRepository
    {
        private DataContext _context;
        private AutoMapper.IConfigurationProvider _config;
        public readonly IMapper _mapper;

        public TVSeriesRepository(DataContext context, IMapper mapper, AutoMapper.IConfigurationProvider config )
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

                var series =  new TVSeries();
                series.Add(tvSeries);
                var show = _context.TVSeries.Add(series);
                await _context.SaveChangesAsync();
                return series;
            }
            throw new ArgumentException("Bad Request, TVSeries exists");
        }

        public async Task<TVSeries> EditTVSeries(TVSeriesViewModel tvSeries)
        {
            var series = new TVSeries();
            series.Update(tvSeries);
            _context.TVSeries.Update(series);
            await _context.SaveChangesAsync();
            return series;
        }

        public async Task<TVSeries?> GetTVSeries(int id)
        {
            return await _context.TVSeries.FindAsync(id);
        }

        public async Task<List<TVSeries>> GetAllTVSeriesByUserId(string userId)
        {
            return await _context.TVSeries
                .AsNoTracking()
                .Where(_ => _.UserKeyId == userId)
                .ToListAsync();
        }
    }
}