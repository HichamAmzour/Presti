using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestiProject_DataAccess.Dapper
{
    public interface IDataBaseManager
    {
        Task<bool> Add(string query="", object param = null);
        Task<bool> Delete(string query="", object param = null);
        Task<T>    Find<T>(string query="", object param = null);
        Task<bool> Modify(string query="", object param = null);
        Task<IEnumerable<T>> Read<T>(string query="", object param = null);
        Task<bool> ExecuteQuery(string query, object param = null);
    }
}
