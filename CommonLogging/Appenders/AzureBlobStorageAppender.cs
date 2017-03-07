using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IG.Extensions;
using log4net.Appender;
using log4net.Core;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

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
            var message = RenderLoggingEvent(loggingEvent);
            var request = loggingEvent.Properties["request"] as HttpRequestMessage;
            if (request != null)
            {
                var headers = JsonConvert.SerializeObject(request.Headers, Formatting.Indented);
                var folderName = request.GetPath();
                var requestId = request.GetHeaderValue("requestId");
                var dumpType = loggingEvent.Properties["dumpType"] as string ?? "NotSpecified";
                var filename = folderName;
                if (folderName != null)
                {
                    filename = $"{filename}{_dumpdir[dumpType]}{requestId}_{dumpType}_{loggingEvent.TimeStampUtc}.json";
                    message = $"Headers:{Environment.NewLine}{headers}{Environment.NewLine}{Environment.NewLine}Payload:{Environment.NewLine}{message}";

                    var blockref = _blobContainer.GetBlockBlobReference(filename);
                    Task.Run( async () => await blockref.UploadTextAsync(message));
                }
            }
        }

        private readonly Dictionary<string, string> _dumpdir = new Dictionary<string, string>
        {
            {"NotSpecified", "unspecified" },
            {"Inbound", "in" },
            {"Cim", "payloads"},
            {"TransformEnrich", "payloads"},
            {"Outbound", "payloads"},
            {"Error", "error" },
        };

    }
}
