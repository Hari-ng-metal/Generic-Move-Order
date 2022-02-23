using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Move_Order
{
    class Connection
    {
        public SqlConnection con;

        public void DatabaseConnection()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=MoveOrder;Integrated Security=True");
        }
    }
}
