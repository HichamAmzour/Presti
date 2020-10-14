using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestiProject_DataAccess
{
    public sealed class ConnectionString
    {
        public static string GetConnectionString( string name="prestiConnection")
        {
            return "Data Source=.;Initial Catalog=PrestiDataBase; Integrated Security=True";
        } 
        
    }
}
