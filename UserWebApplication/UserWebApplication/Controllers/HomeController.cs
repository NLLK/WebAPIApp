using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace UserWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebRequest request = WebRequest.Create("https://randomuser.me/api/");
            WebResponse response = request.GetResponse();
            string responseString;

            var encoding = Encoding.UTF8;

            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseString = reader.ReadToEnd();
            }
            var user = JsonConvert.DeserializeObject(responseString);
            ViewBag.User = user;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}