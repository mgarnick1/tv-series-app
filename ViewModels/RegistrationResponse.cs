namespace tv_series_app.ViewModels
{
    public class RegistrationResponse
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}