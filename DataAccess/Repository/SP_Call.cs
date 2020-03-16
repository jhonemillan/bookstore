using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public class SP_Call : I_SP_Call
    {
        private readonly ApplicationDbContext context;
        private string connectionString = "";

        public SP_Call(ApplicationDbContext c)
        {
            this.context = c;
            this.connectionString = c.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Execute(string spName, DynamicParameters param = null)
        {
            using(SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                sqlconn.Open();
                sqlconn.Execute(spName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string spName, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public T OneRecord<T>(string spName, DynamicParameters param = null)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                sqlconn.Open();
                var value = sqlconn.Query<T>(spName, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public T Single<T>(string spName, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }
    }
}
