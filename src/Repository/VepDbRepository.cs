using Repository.DataAccess;

namespace Repository
{
    public class VepDbRepository : IVepDbRepository
    {
        public IProcedureExecutor Execute { get; }

        public VepDbRepository(IProcedureExecutor procedureExecutor) => Execute = procedureExecutor;
    }
}
