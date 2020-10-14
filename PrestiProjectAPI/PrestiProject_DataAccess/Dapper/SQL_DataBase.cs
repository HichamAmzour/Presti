using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrestiProject_DataAccess.Dapper
{
    public class SQL_DataBase: IDataBaseManager
    {
        IDbConnection _connection;

        public SQL_DataBase()
        {
            _connection = new SqlConnection(ConnectionString.GetConnectionString());
        }

        public async Task<IEnumerable<T>> Read<T>(string query="", object param=null)
        {
            using (_connection)
            {
               var list = await _connection.QueryAsync<T>(query,param);

               return list.ToList();
            }
        }

        public async Task<bool> Delete(string query="", object param = null)
        {
            return await ExecuteQuery(query, param);
        }

        public async Task<bool> Modify(string query="", object param = null)
        {
            return await ExecuteQuery(query, param);
        }

        public async Task<bool> Add(string query="", object param = null)
        {
           return await ExecuteQuery(query,  param);
        }

        public async Task<T> Find<T>(string query="", object param = null)
        {
            using (_connection)
            {
                var item = await _connection.QueryAsync<T>(query, param);
               
                return item.SingleOrDefault();
            }
        }

        public async Task<bool> ExecuteQuery(string query,object param=null)
        {
            using (_connection)
            {
                var p = new DynamicParameters();
                p.Add(name:"@error",value:0,dbType:DbType.Int32,direction:ParameterDirection.ReturnValue);
                p.AddDynamicParams(param);
               
                await _connection.ExecuteAsync(query, p,commandType:CommandType.StoredProcedure);

                return p.Get<int>("@error") == 0;
            }
        }
    }
}
