using Dapper;
using MySqlConnector;
using System.Data;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public partial class ProcedureExecutor
    {
        public async Task LoadTodaysTransactions()
        {
            using var sqlConnection = new MySqlConnection(_connectionString);

            await sqlConnection.ExecuteAsync("load_todays_transactions", commandType: CommandType.StoredProcedure);
        }
    }
}
