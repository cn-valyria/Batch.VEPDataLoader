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

        [FunctionName(nameof(LoadTodaysData))]
        public async Task LoadTodaysData([TimerTrigger("0 30 13 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"{nameof(LoadTodaysData)} function started execution at: {DateTime.Now}");

            await _vepDbRepository.Execute.LoadTodaysTransactions();

            log.LogInformation("Function has executed load_todays_transactions successfully.");

            await _vepDbRepository.Execute.LoadTodaysLists();

            log.LogInformation("Function has executed load_todays_lists successfully.");

            log.LogInformation($"{nameof(LoadTodaysData)} function completed execution at: {DateTime.Now}");
        }
    }
}
