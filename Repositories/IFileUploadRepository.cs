using System;

namespace tv_series_app.Repositories
{
    public interface IFileUploadRepsitory 
    {
        public Task<string> UploadFileRetrieveLink(Stream Content, string fileName, string userId);
    }
}