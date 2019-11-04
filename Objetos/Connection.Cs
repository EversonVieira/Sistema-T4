using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DentAnalyst.Objetos
{
    class Connection
    {
        public SqlConnection conn;
        
        public Connection()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConnInfo().ConnectionString;
            conn.Open();
        }
        public SqlConnectionStringBuilder ConnInfo()
        {
            SqlConnectionStringBuilder aux = new SqlConnectionStringBuilder();
            aux.DataSource = "----";
            aux.InitialCatalog = "----";
            aux.UserID = "----";
            aux.Password = "----";
            return aux;
        }

    }
}
