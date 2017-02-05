using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace reservation.DBHotel
{
    public class Commandes_Hotel
    {
        public void reservation_hotel(string client, int hotel)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data source=(local)\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security = true";
            conn.Open();
            SqlCommand command = new SqlCommand("insert_commande_hotel", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CLIENT", SqlDbType.NChar);
            command.Parameters["@CLIENT"].Value = client;
            command.Parameters.Add("@HOTEL", SqlDbType.Int);
            command.Parameters["@HOTEL"].Value = hotel;
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
    }
}
