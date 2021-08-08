using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public class TimerEntryPoint
    {
        [FunctionName(nameof(VEPTransactionsLoader))]
        public void VEPTransactionsLoader([TimerTrigger("0 0 2,14 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
