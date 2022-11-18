using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace WPF_ZooManager
{
    class SqlliteDataAccess
    {

        public static string LoadPeople()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //var output = cnn.Query<string>("select * from Person", new DynamicParameters());
                var output1 = cnn.QueryFirstOrDefault<string>("SELECT FirstName FROM Person", new { Id = 1 });
                return output1;
            }


        }

  


        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
