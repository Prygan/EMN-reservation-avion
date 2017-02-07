using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;

namespace WSVol.Controllers
{
    public class Vol
    {
        public int ID { get; set; }
        public String VilleDepart { get; set; }
        public String VilleArrivee { get; set; }
        public TimeSpan Duree { get; set; }
        public DateTime DateDepart { get; set; }
    }

    public class Commande
    {
        public int Vol { get; set; }
        public String Client { get; set; }
    }
    [RoutePrefix("api/vol")]
    public class VolController : ApiController
    {
        // GET api/Vol
        //Retourne tous les vols
        [HttpGet]
        public IEnumerable<Vol> Get()
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Vol;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("select_vols", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            SqlDataReader Reader = MyCom.ExecuteReader();
            List<Vol> Vols = new List<Vol>();
            while (Reader.Read())
            {
                int IDRead = Reader.GetInt32(0);
                String VilleDepartRead = Reader.GetString(1);
                String VilleArriveeRead = Reader.GetString(2);
                TimeSpan DureeRead = Reader.GetTimeSpan(3);
                DateTime DateDepartRead = Reader.GetDateTime(4);
                Vols.Add(new Vol { ID = IDRead, VilleDepart = VilleDepartRead, VilleArrivee = VilleArriveeRead, Duree = DureeRead, DateDepart = DateDepartRead });
            }
            MyCom.Dispose();
            MyC.Close();

            return Vols;
        }

        // GET api/Vol/VillesDepart
        // Retourne les villes de départ
        [HttpGet]
        [Route("VillesDepart")]
        public IEnumerable<String> GetVillesDepart()
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Vol;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("select_villeDepart", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            SqlDataReader Reader = MyCom.ExecuteReader();
            List<String> VillesDepart = new List<String>();
            while (Reader.Read())
            {
                String VilleDepartRead = Reader.GetString(0);
                VillesDepart.Add(VilleDepartRead);
            }
            MyCom.Dispose();
            MyC.Close();

            return VillesDepart;
        }

        // GET api/Vol/VillesArrivee/{VilleDepart}
        //Retourne les villes d'arrivée selon une ville de départ
        [HttpGet]
        [Route("VillesArrivee/{VilleDepart}")]
        public IEnumerable<String> GetVillesArrivee(String VilleDepart)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Vol;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("select_villeArrivee", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@VILLEDEPART", SqlDbType.VarChar);
            MyCom.Parameters["@VILLEDEPART"].Value = VilleDepart;
            SqlDataReader Reader = MyCom.ExecuteReader();
            List<String> VillesArrivee = new List<String>();
            while (Reader.Read())
            {
                String VilleArriveeRead = Reader.GetString(0);
                VillesArrivee.Add(VilleArriveeRead);
            }
            MyCom.Dispose();
            MyC.Close();

            return VillesArrivee;
        }

        // GET api/VolsParVilles/{VolVilleDepart}/{VilleArrivee}
        // retourne tous les vols par ville de départ et ville d'arrivée
        [HttpGet]
        [Route("VolsParVilles/{VilleDepart}/{VilleArrivee}")]
        public IEnumerable<Vol> GetVolsParVilles(String VilleDepart, String VilleArrivee)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Vol;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("select_volsParVilles", MyC);
            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@VILLEDEPART", SqlDbType.VarChar);
            MyCom.Parameters["@VILLEDEPART"].Value = VilleDepart;
            MyCom.Parameters.Add("@VILLEARRIVEE", SqlDbType.VarChar);
            MyCom.Parameters["@VILLEARRIVEE"].Value = VilleArrivee;
            SqlDataReader Reader = MyCom.ExecuteReader();
            List<Vol> Vols = new List<Vol>();
            while (Reader.Read())
            {
                int IDRead = Reader.GetInt32(0);
                String VilleDepartRead = Reader.GetString(1);
                String VilleArriveeRead = Reader.GetString(2);
                TimeSpan DureeRead = Reader.GetTimeSpan(3);
                DateTime DateDepartRead = Reader.GetDateTime(4);
                Vols.Add(new Vol { ID = IDRead, VilleDepart = VilleDepartRead, VilleArrivee = VilleArriveeRead, Duree = DureeRead, DateDepart = DateDepartRead });

            }
            MyCom.Dispose();
            MyC.Close();

            return Vols;
        }


        // PUT api/Vol
        [HttpPut]
        public void Put(int id, [FromBody]Commande Commande)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = "Data Source=FLORINECERCD9F9\\SQLEXPRESS;Initial Catalog=Vol;Integrated Security = true";
            MyC.Open();
            SqlCommand MyCom = new SqlCommand("insert_commande_vol", MyC);

            MyCom.CommandType = CommandType.StoredProcedure;
            MyCom.Parameters.Add("@VOL", SqlDbType.Int);
            MyCom.Parameters["@VOL"].Value = Commande.Vol;
            MyCom.Parameters.Add("@CLIENT", SqlDbType.VarChar);
            MyCom.Parameters["@CLIENT"].Value = Commande.Client;
            MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            MyC.Close();
        }


    }
}
