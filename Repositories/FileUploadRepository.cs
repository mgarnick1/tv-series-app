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

        public async Task<string> UploadFileRetrieveLink(Stream content, string fileName, string userId)
        {
            var connectionString = _config["BlobContainer:ConnectionString"];
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(userId);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(content, true);

            
            return blobClient.Uri.OriginalString;
        }
    }
}