using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace tv_series_app.Models
{
    public class TVSeries
    {
        [Key]
        public int Id { get; protected set; }
        [StringLength(256)]
        public string? Name { get; protected set; }
        public string? ShowImage { get; protected set; }
        public string? Description { get; protected set; }
        public double? Rating { get; protected set; }
        [StringLength(256)]
        public string? Genre { get; protected set; }
        public string? UserKeyId { get; set; }
        public User? User { get;  set; }
    }
}