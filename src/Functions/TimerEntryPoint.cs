using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Repository;

namespace Functions
{
    public class TimerEntryPoint
    {
        private IVepDbRepository _vepDbRepository;

        public TimerEntryPoint(IVepDbRepository vepDbRepository) => _vepDbRepository = vepDbRepository;

        [FunctionName(nameof(VEPTransactionsLoader))]
        public async Task VEPTransactionsLoader([TimerTrigger("0 0 2,14 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"{nameof(VEPTransactionsLoader)} function started execution at: {DateTime.Now}");

            await _vepDbRepository.Execute.LoadTodaysTransactions();

            log.LogInformation($"{nameof(VEPTransactionsLoader)} function completed execution at: {DateTime.Now}");
        }
    }
}
