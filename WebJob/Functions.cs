using System.IO;
using Microsoft.Azure.WebJobs;

namespace WinService.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([TimerTrigger("")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }
    }
}
