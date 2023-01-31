using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using tv_series_app.ViewModels;
using Newtonsoft.Json;

namespace tv_series_app.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _config;

        public EmailRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendEmailRecommendation(EmailModel model, CancellationToken cancellationToken)
        {
            RestClient client = new RestClient("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", _config["MailGun:ApiKey"]);
            string domain = _config["MailGun:Domain"];
            RestRequest request = new RestRequest();    
            var friendName = !string.IsNullOrEmpty(model.FriendName) ? model.FriendName : "";
            var seriesName = !string.IsNullOrEmpty(model.Series) ? model.Series : "";
            var network = !string.IsNullOrEmpty(model.Network) ? model.Network : "";
            var image = !string.IsNullOrEmpty(model.Image) ? model.Image : "";
            var tvSeriesDictionary = new Dictionary<string, string>();
            tvSeriesDictionary.Add("friend_name", friendName);
            tvSeriesDictionary.Add("series_name", seriesName);
            tvSeriesDictionary.Add("network", network);
            tvSeriesDictionary.Add("show_image", image);
           var jsonString = JsonConvert.SerializeObject(tvSeriesDictionary);
            request.AddParameter("domain", domain, ParameterType.UrlSegment);
            request.Resource = $"{domain}/messages";
            request.AddParameter("from", model.From);
            request.AddParameter("to", model.To);
            request.AddParameter("subject", model.Subject);
            request.AddParameter("template", "tvshow_recommendation");
            request.AddParameter("h:X-Mailgun-Variables", jsonString);
            bool result = false;
            try
            {

                await client.ExecutePostAsync(request, cancellationToken);
                result = true;
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err);

            }
            return result;

        }
    }
}