using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace WSHotels.Controllers
{
    public class Hotel
    {
        public int ID { get; set; }
        public String ville { get; set; }
        public String nom { get; set; }
    }
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        // GET api/Hotels
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
              SqlConnection MyC = new SqlConnection();
              MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security = true";
              MyC.Open();
              SqlCommand MyCom = new SqlCommand("select_hotels", MyC);
             MyCom.CommandType = CommandType.StoredProcedure;

            /*  MyCom.Parameters.Add("@Montant", SqlDbType.Int);
                  MyCom.Parameters["@Montant"].Value = Montant;
                  MyCom.Parameters.Add("@Compte", SqlDbType.Int);
                  MyCom.Parameters["@Compte"].Value = CD;*/
              IDataReader Reader = MyCom.ExecuteReader();
            List<Hotel> Hotels = new List<Hotel>();
            while (Reader.Read())
            {
                int IDRead = Reader.GetInt32(0);
                String villeRead = Reader.GetString(1);
                String nomRead = Reader.GetString(2);
                Hotels.Add(new Hotel { ID = IDRead, ville = villeRead, nom = nomRead });
            }
            MyCom.Dispose();
             MyC.Close();

            return Hotels;
  
        }

        // GET api/Hotels/5
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return null;
        }

        // POST api/Hotels
        [HttpPost]
        public void Post([FromBody]Hotel Hotel)
        {
        }

        // PUT api/Hotels/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Hotel Hotel)
        {
        }

        // DELETE api/Hotels/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
