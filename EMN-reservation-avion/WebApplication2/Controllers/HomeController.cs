using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Xml;
using System.IO;
using System.Text;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
            var hotelResponse = client.GetAsync("http://localhost:52562/api/Hotel").Result;
            String hotelsXml = hotelResponse.Content.ReadAsStringAsync().Result;
            var villesOrigineResponse = client.GetAsync("http://localhost:53328/api/vol/VillesDepart").Result;
            String villesOrigine = villesOrigineResponse.Content.ReadAsStringAsync().Result;
            ViewBag.Test = villesOrigine;
            return View();
        }

        private List<String> parseXmlHotels(String xml)
        {
            List<String> l = new List<String>();
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                reader.ReadToFollowing("Hotel");
                l.Add(reader.ReadElementContentAsString());
            }
            return l;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
