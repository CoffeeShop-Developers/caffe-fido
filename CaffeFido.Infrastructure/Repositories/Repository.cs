using Microsoft.EntityFrameworkCore;
using CaffeFido.Core.Helpers;
using CaffeFido.Core.Interfaces;
using CaffeFido.Infrastructure.Configuration.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeFido.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> StoredProcedure<P>(string storedProcedureName, P parameters)
        {
            if (typeof(P).GetProperties().Length == 0)
                return await _dbContext.Query<T>().FromSqlRaw($"{storedProcedureName}").ToListAsync();
            var parameterString = SqlHelpers.StringifyParameters<P>(parameters);
            var sqlParameters = SqlHelpers.CreateSqlParameters<P>(parameters);

            return await _dbContext.Query<T>().FromSqlRaw($"{storedProcedureName} {parameterString}", sqlParameters).ToListAsync();
        }

        public async Task<IEnumerable<SqlParameter>> StoredProcedureWithOutput<P>(string storedProcedureName, P parameters)
        {
            if (typeof(P).GetProperties().Length == 0) return null;
            var parameterString = SqlHelpers.StringifyParametersWithOutput<P>(parameters);
            var sqlParameters = SqlHelpers.CreateSqlParameters<P>(parameters);
           
            var result = await _dbContext.Database
                .ExecuteSqlRawAsync($"exec {storedProcedureName} {parameterString}", sqlParameters);
               
            return sqlParameters.Where(s => s.Direction == System.Data.ParameterDirection.Output);
        }

        public async Task<int> StoredProcedureVoid<P>(string storedProcedureName, P parameters)
        {
            if (typeof(P).GetProperties().Length == 0)
                return await _dbContext.Database.ExecuteSqlRawAsync($"exec {storedProcedureName}");
            var parameterString = SqlHelpers.StringifyParameters<P>(parameters);
            var sqlParameters = SqlHelpers.CreateSqlParameters<P>(parameters);
               
            return await  _dbContext.Database.ExecuteSqlRawAsync($"{storedProcedureName} {parameterString}", parameters);
        }

        public async Task<IEnumerable<T>> RawSql(string sqlString)
        {
            return await _dbContext.Query<T>().FromSqlRaw(sqlString).ToListAsync();
        }
    }
}
