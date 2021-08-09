using Repository.DataAccess;

namespace Repository
{
    public interface IVepDbRepository
    {
        IProcedureExecutor Execute { get; }
    }
}
