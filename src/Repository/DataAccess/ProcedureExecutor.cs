namespace Repository.DataAccess
{
    public partial class ProcedureExecutor : IProcedureExecutor
    {
        protected readonly string _connectionString;

        public ProcedureExecutor(string connectionString) => _connectionString = connectionString;
    }
}
