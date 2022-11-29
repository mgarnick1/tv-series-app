

using tv_series_app.Models;

namespace tv_series_app.ViewModels
{
    public class UserTVSeriesModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public List<TVSeries>? TVSeries { get; set; }
    }
}