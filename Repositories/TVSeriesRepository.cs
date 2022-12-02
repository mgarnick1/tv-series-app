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
        public readonly IMapper _mapper;

        public TVSeriesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }

        public async Task<TVSeries> AddTVSeries(TVSeriesViewModel tvSeries)
        {
            var exists = _context.TVSeries.FirstOrDefault(_ => _.Name == tvSeries.Name && _.User.Id == tvSeries.UserId);
            if (exists == null)
            {

                var mapped = _mapper.Map<TVSeries>(tvSeries);
                var show = _context.TVSeries.Add(mapped);
                await _context.SaveChangesAsync();
                return mapped;
            }
            throw new ArgumentException("Bad Request, TVSeries exists");
        }

        public async Task<TVSeries> EditTVSeries(TVSeriesViewModel tvSeries)
        {
            var mapped = _mapper.Map<TVSeries>(tvSeries);
            _context.TVSeries.Update(mapped);
            await _context.SaveChangesAsync();
            return mapped;
        }

        public async Task<TVSeries?> GetTVSeries(int id)
        {
            return await _context.TVSeries.FindAsync(id);
        }

        public async Task<List<TVSeries>> GetAllTVSeriesByUserId(string userId)
        {
            return await _context.TVSeries
                .AsNoTracking()
                .Where(_ => _.User.Id == userId)
                .ToListAsync();
        }
    }
}