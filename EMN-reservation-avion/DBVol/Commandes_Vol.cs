using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace reservation.DBVol
{
    public class Commandes_Vol
    {
        public void reservation_vol(string client, int vol)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data source=(local)\\SQLEXPRESS;Initial Catalog=Vol;Integrated Security = true";
            conn.Open();
            SqlCommand command = new SqlCommand("insert_commande_vol", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CLIENT", SqlDbType.NChar);
            command.Parameters["@CLIENT"].Value = client;
            command.Parameters.Add("@VOL", SqlDbType.Int);
            command.Parameters["@VOL"].Value = vol;
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
    }
}
