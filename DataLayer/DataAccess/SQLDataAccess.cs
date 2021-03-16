using System.Collections.Generic;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataAccess
{
    public static class SQLDataAccess
    {
        public static string GetConnectionString(string connectionName = "SovosDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T> (string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).AsList();
            }
        }
    }
}
