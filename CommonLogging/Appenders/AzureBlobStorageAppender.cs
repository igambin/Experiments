using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using log4net.Core;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CommonLogging.Appenders
{
    public class AzureBlobStorageFileDumpAppender : AppenderSkeleton
    {
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _blobContainer;

        public string AzureStorageConnectionString { get; set; }
        public string BlobContainerReferenceName { get; set; }

        public override void ActivateOptions()
        {
            _storageAccount = CloudStorageAccount.Parse(AzureStorageConnectionString);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(BlobContainerReferenceName);
            _blobContainer.CreateIfNotExists();

            base.ActivateOptions();
        }




        protected override void Append(LoggingEvent loggingEvent)
        {
            var message = this.RenderLoggingEvent(loggingEvent);
            var folderName = loggingEvent.Properties["folderName"] as string;
            if (folderName != null)
            {
                var basefolder = folderName;

            }
            else
            {
                // render logging error
            }



        }


    }
}
