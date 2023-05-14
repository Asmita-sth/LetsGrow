using Dapper;
using Letsgrow.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Letsgrow.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config) {
            this._config = config;
         
        }



        public  async Task<dynamic> GetData<T,P>(string spName, P parameters, string connectionId = "default") 
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var result = await connection.QuerySingleOrDefaultAsync(spName, parameters, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task SaveData<T>(string spName, T parameters, string connectionId = "default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
