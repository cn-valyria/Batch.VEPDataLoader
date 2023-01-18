using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public interface IProcedureExecutor
    {
        Task LoadTodaysTransactions();
        Task LoadTodaysLists();
    }
}
