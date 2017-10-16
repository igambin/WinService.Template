using System;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Core;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using WinService.Extensions;
using WinService.Logging.LogModels;

namespace WinService.Logging.Appenders
{
    public class AzureBlobStorageAppender : AppenderSkeleton
    {
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _blobContainer;

        public string AzureStorageConnectionString { get; set; }
        public string BlobContainerReferenceName { get; set; } 

        public override void ActivateOptions()
        {
            try
            {
                _storageAccount = CloudStorageAccount.Parse(AzureStorageConnectionString);
                _blobClient = _storageAccount.CreateCloudBlobClient();
                _blobContainer = _blobClient.GetContainerReference(BlobContainerReferenceName);
                _blobContainer.CreateIfNotExists();

                base.ActivateOptions();
            }
            catch (Exception ex)
            {
                this.FileLogger().Warn("Configuring AzureStorage failed!", ex);
            }
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (_blobContainer == null) return;
                
            var logItem = ThreadContext.Properties["logItem"] as LogItem;
            try
            {
                string filename = logItem?.BlobName ?? $"AzureBlobStorageAppender/MissingFilename_{DateTime.Now:yyyyMMddHHmmssfffffff}.txt";
                string message = logItem?.BlobLogMessage ?? "[null]";

                if (ThreadContext.Properties["caller"] is string caller)
                    message = caller.AppendLine(message);

                var blockref = _blobContainer.GetAppendBlobReference(filename);
                blockref.CreateOrReplace();
                blockref.AppendText(message, Encoding.UTF8);

                if (logItem?.PayloadStream != null)
                    blockref.AppendFromByteArray(logItem.PayloadStream, 0, logItem.PayloadStream.Length);
                
                if (ThreadContext.Properties["stacktrace"] is string stacktrace)
                    blockref.AppendText("".AppendNewLine(2).AppendLine($"Log-CallStack : {stacktrace}"));
               
            }
            catch (Exception e)
            {
                this.FileLogger().Warn("Appending Log to AzureStorage failed!", e);
            }
        }
    }
}
