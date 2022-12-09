using System;
using AutoMapper;
using tv_series_app.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace tv_series_app.Repositories
{
    public class FileUploadRepository : IFileUploadRepsitory
    {
        private readonly DataContext _context;

        private AutoMapper.IConfigurationProvider _mapconfig;
        public readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public FileUploadRepository(DataContext context, AutoMapper.IConfigurationProvider mapconfig, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapconfig = mapconfig;
            _mapper = mapper;
            _config = config;
        }

        public async Task<string> UploadFileRetrieveLink(string localFilePath)
        {
            var connectionString = _config["BlobContainer:ConnectionString"];
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            string fileName = Path.GetFileName(localFilePath);
            BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer("tvSeriesContainer");
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(localFilePath, true);

            BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
            string downloadedData = downloadResult.Content.ToString();
            return downloadedData;
        }
    }
}