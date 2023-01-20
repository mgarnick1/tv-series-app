
using System;

namespace tv_series_app.ViewModels
{
    public class EpisodeDateViewModel
    {
        public string? total { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public List<EpisodeDateTVShowsViewModel>? tv_shows { get; set; }
    }

    public class EpisodeDateTVShowsViewModel
    {
        public int id { get; set; }
        public string? permalink { get; set; }
        public string? name { get; set; }
        public string? start_date { get; set; }
        public string? end_date { get; set; }
        public string? country { get; set; }
        public string? network { get; set; }
        public string? genre { get; set; }
        public int? networkId { get; set; }
        public string? status { get; set; }
        public string? image_thumbnail_path { get; set; }

    }
}