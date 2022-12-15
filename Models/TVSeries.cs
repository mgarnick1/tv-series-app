using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using tv_series_app.ViewModels;

namespace tv_series_app.Models
{
    public class TVSeries
    {

        public TVSeries Add(TVSeriesViewModel model) 
        {
            this.Name = model.Name;
            this.Description = model.Description;
            this.ShowImage = model.ShowImage;
            this.Rating = model.Rating;
            this.Genre = model.Genre;
            this.UserId = model.UserId;
            this.Network = model.Network;
            return this;
        }

        public TVSeries Update(TVSeriesViewModel model) 
        {
            this.Name = model.Name;
            this.Description = model.Description;
            this.ShowImage = model.ShowImage;
            this.Rating = model.Rating;
            this.Genre = model.Genre;
            this.Network = model.Network;
            return this;
        }

        [Key]
        public int Id { get; protected set; }
        [StringLength(256)]
        public string? Name { get; protected set; }
        public string? ShowImage { get; protected set; }
        public string? Description { get; protected set; }
        public int? Rating { get; protected set; }
        [StringLength(256)]
        public string? Genre { get; protected set; }
        public string? UserId { get; set; }
        public virtual User? User { get;  set; }
        [StringLength(32)]
        public string? Network { get; set; }

    }
}