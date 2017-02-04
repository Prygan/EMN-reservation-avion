using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Net.Http;
using System.Net;

namespace WSHotel.Controllers
{
    public class Hotel
    {
        public int ID { get; set; }
        public String Ville { get; set; }
        public String Nom { get; set; }
    }

    public class Commande
    {
        // public int ID { get; set; }
        public int Hotel { get; set; }
        public String Client { get; set; }
    }
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        // GET api/Hotel
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("select_hotels", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            IDataReader Reader = MyCom.ExecuteReader();
            List<Hotel> Hotels = new List<Hotel>();
            while (Reader.Read())
            {
                int IDRead = Reader.GetInt32(0);
                String VilleRead = Reader.GetString(1);
                String NomRead = Reader.GetString(2);
                Hotels.Add(new Hotel { ID = IDRead, Ville = VilleRead, Nom = NomRead });
            }
            MyCom.Dispose();
            MyC.Close();

            return Hotels;

        }

        // PUT api/Hotel
        [HttpPut]
        public void Put([FromBody]Commande Commande)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security = true";
            MyC.Open();

            SqlCommand MyCom = new SqlCommand("insert_commande_hotel", MyC);

            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@HOTEL", SqlDbType.Int);
            MyCom.Parameters["@HOTEL"].Value = Commande.Hotel;
            MyCom.Parameters.Add("@CLIENT", SqlDbType.VarChar);
            MyCom.Parameters["@CLIENT"].Value = Commande.Client;
            MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            MyC.Close();
        }

      
    }
}
