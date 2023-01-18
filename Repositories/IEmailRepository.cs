using System;
using tv_series_app.ViewModels;

namespace tv_series_app.Repositories
{
    public interface IEmailRepository
    {
       public Task<bool> SendEmailRecommendation(EmailModel email, CancellationToken cancellationToken);
    }
}