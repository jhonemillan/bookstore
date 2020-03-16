using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface I_SP_Call: IDisposable
    {
        T Single<T>(string spName, DynamicParameters param =null);

        void Execute(string spName, DynamicParameters param = null);

        T OneRecord<T>(string spName, DynamicParameters param = null);

        IEnumerable<T> List<T>(string spName, DynamicParameters param = null);

    

    }
}
