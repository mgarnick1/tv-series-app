using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace tv_series_app.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public virtual List<TVSeries>? TVSeries { get; set; }

}
