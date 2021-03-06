using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetImageGallery.Services
{
    public class BlobStorageService
    {
        string connectionString;
        string containerName;
        IConfiguration _config;

        public BlobStorageService(IConfiguration configuration)
        {
            _config = configuration;
            connectionString = _config["Storage:Connection"];
            containerName = _config["Storage:Container"];
        }

        private string GenerateFileName(string fileName)
        {
            string[] strName = fileName.Split('.');
            string strFileName = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }

        public async Task<string> UploadFileToBlobAsync(string strFileName, Stream content, string contentType)
        {
            string fileName = this.GenerateFileName(strFileName);
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.CreateIfNotExists();

            BlobClient blob = container.GetBlobClient(fileName);
            await blob.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
            return blob.Uri.ToString();
        }

        public async void DeleteBlobData(string fileUrl)
        {
            Uri uriObj = new Uri(fileUrl);
            string BlobName = Path.GetFileName(uriObj.LocalPath);

            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            BlobClient blob = container.GetBlobClient(BlobName);
            await blob.DeleteAsync();
        }
    }
}
