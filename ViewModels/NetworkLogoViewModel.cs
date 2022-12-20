using System;
using tv_series_app.Models;

namespace tv_series_app.ViewModels
{
    public class NetworkLogoViewModel
    {
        public int Id { get; set; }
        public string? NetworkName { get; set; }
        public string? LogoUrl { get; set; }
        public string? UserId { get; set; }
        
    }
}