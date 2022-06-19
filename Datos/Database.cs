using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Database
    {
        private SqlConnection con;
        public SqlConnection ConectaDb()
        {
            try
            {
                string cadenaconexion = "Data Source=DESKTOP-K3OI6F9\\ORBEZO;Initial Catalog=TF;Integrated Security=True";
                con = new SqlConnection(cadenaconexion);
                con.Open();
                return con;
            }
            catch (SqlException e)
            {
                return null;
            }
        }
        public void DesconectaDb()
        {
            con.Close();
        }
    }
}
