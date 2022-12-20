
using System.ComponentModel.DataAnnotations;

namespace tv_series_app.Models
{
    public class NetworkLogo
    {
        [Key]
        public int Id { get; protected set; }
        [StringLength(32)]
        public string? NetworkName { get; set; }
        [StringLength(1024)]
        public string? LogoUrl { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}