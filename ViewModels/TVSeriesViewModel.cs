using System;
using tv_series_app.Models;

namespace tv_series_app.ViewModels
{
    public class TVSeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShowImage { get; set; } 
        public string? Description { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set; } = null!;
        public string Genre { get; set; } = null!;
    }
}