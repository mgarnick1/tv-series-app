
using System.ComponentModel.DataAnnotations;
using tv_series_app.ViewModels;

namespace tv_series_app.Models
{
    public class NetworkLogo
    {
        public NetworkLogo Add(NetworkLogoViewModel model) 
        {
            this.NetworkName = model.NetworkName;
            this.LogoUrl = model.LogoUrl;
            this.UserId = model.UserId;
            return this;   
        }

        public NetworkLogo Update(NetworkLogoViewModel model)
        {
            this.NetworkName = model.NetworkName;
            this.LogoUrl = model.LogoUrl;
            this.UserId = model.UserId;
            return this;
        }
        
        [Key]
        public int Id { get; protected set; }
        [StringLength(32)]
        public string? NetworkName { get; set; }
        [StringLength(1024)]
        public string? LogoUrl { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual List<TVSeries>? TVSeries { get; set; }
    }
}