using Fiotec.Pacto.Infra.Data.Context.Abastraction;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Fiotec.Pacto.Infra.Data.Context
{
    public sealed class SqlConnectionContext(IConfiguration _configuration) : ISqlConnectionContext
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
