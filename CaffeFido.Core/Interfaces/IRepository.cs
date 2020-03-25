using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaffeFido.Core.Interfaces
{
   
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> StoredProcedure<P>(string storedProcedureName, P parameters);

        Task<IEnumerable<SqlParameter>> StoredProcedureWithOutput<P>(string storedProcedureName, P parameters);

        Task<IEnumerable<T>> RawSql(string sqlString);

        Task<int> StoredProcedureVoid<P>(string storedProcedureName, P parameters);
    }
}
