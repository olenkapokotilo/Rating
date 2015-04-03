using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft;
using Newtonsoft.Json;


namespace ApiClient.Controllers
{
    public class HomeController : Controller
    {
        public const string BaseUri = "http://localhost:2250/api/";

        public ActionResult Index()
        {
            User user = new User();
            user.Name="qwe"; user.Age=21;user.Country="usa";
            string jsonUser = JsonConvert.SerializeObject(user);
            
            var responseGet = SendGetRequest(BaseUri + "user/123");
            var responsePost = SendPostRequest(jsonUser, BaseUri + "user");
            return View();
        } 
       // public string url = "api/products/1";
        public static string SendGetRequest(string url)
        {
            string result=string.Empty;
            WebRequest httpRequest = HttpWebRequest.Create(url);
            httpRequest.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);

            using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
            {
                result = sr.ReadToEnd();
            }

            return result; //httpRequest.GetResponse();
        }

        public static string SendPostRequest(object data, string url)
        {
            string result = string.Empty;
            var httpRequest = HttpWebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            //httpRequest.ContentLength = data.Length;
            using(StreamWriter sw = new StreamWriter(httpRequest.GetRequestStream()))
            {
                sw.Write(data);
            }
            //var streamWriter = new StreamWriter(httpRequest.GetRequestStream());
            //streamWriter.Write(data);
            //streamWriter.Close();
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            //Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            return result; //httpRequest.GetResponse();
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
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Country { get; set; }
        }
    }
}