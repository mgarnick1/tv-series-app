namespace tv_series_app.Models
{
    public class AuthResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
    }
}