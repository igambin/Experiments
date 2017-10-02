using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;

namespace IG.WebJobs
{
    public class Functions
    {
        #region Queue-Triggers
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }

        public static void ProcessQueueMyObject([QueueTrigger("logqueue")] MyObject myObject, TextWriter logger)
        {
            logger.WriteLine("Queue message refers to object: " + myObject.Name);
        }
        #endregion


        #region BlobFileTriggers
        public static void ProcessBlobFile([BlobTrigger("blobPath")] string blobPath, TextWriter log)
        {
            log.WriteLine(blobPath);
        }
        #endregion


        #region TableTriggers
        public static void ReadTable([Table("MyObjectTable")] IQueryable<MyObject> tableBinding, TextWriter logger)
        {
            tableBinding.ToList().ForEach(mo => logger.WriteLine($"MyObj: {mo.Name}"));
        }
        #endregion




        #region ServiceBusTrigger
        public static void ProcessServiceBusQueueMessage([ServiceBusTrigger("inputQueue")] string message, TextWriter logger)
        {
            logger.WriteLine(message);
        }

        public static void ProcessServiceBusTopicMessage([ServiceBusTrigger("outputtopic", "subscription1")] string message, TextWriter logger)
        {
            logger.WriteLine("Topic message: " + message);
        }
        #endregion

        #region TimerTrigger (requires config to register config.UserTimers() in program.cs)
        public static void CronJob([TimerTrigger("0 */5 * * * *")] TimerInfo timer, TextWriter logger)
        {
            logger.WriteLine("Cron job fired!");
        }

        public static void StartupJob([TimerTrigger("0 0 */2 * * *", RunOnStartup = true)] TimerInfo timerInfo, TextWriter logger)
        {
            logger.WriteLine("Startup-TimerJob fired!");
        }

        // Runs once every 30 seconds
        public static void TimerJob([TimerTrigger("00:00:30")] TimerInfo timer, TextWriter logger)
        {
            logger.WriteLine("Timer job fired!");
        }
        #endregion


        #region FileTrigger (requires config to register config.UseFiles() in program.cs)
        public static void ImportFile(
            [FileTrigger(@"import\{name}", "*.dat", autoDelete: true)] Stream file,
            [Blob(@"processed/{name}")] CloudBlockBlob output,
            string name
            , TextWriter logger)
        {
            output.UploadFromStream(file);
            file.Close();

            logger.WriteLine(string.Format("Processed input file '{0}'!", name));
        }
        #endregion
    }

    public class MyObject
    {
        public string Name { get; set; }
    }
}
