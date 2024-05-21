using System.Data.SqlClient;

namespace Fiotec.Pacto.Infra.Data.Context.Abastraction
{
    public interface ISqlConnectionContext
    {
        SqlConnection CreateConnection();
    }
}
