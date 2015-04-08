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
using ApiClient.Models;
using ApiClient.Services;


namespace ApiClient.Controllers
{
    public class HomeController : Controller
    {
        public const string BaseUri = "http://localhost:2250/api/";
        ClientContext db = new ClientContext();

        private IRequestService<ProjectUser> projectUserService;
        public HomeController()
        {
            projectUserService = new JsonRequestService<ProjectUser>(BaseUri + "user/");
        }
        public ActionResult Show()
        {
            return View(db.ProjectUsers);
        }
        public ActionResult Index()
        {
            //ProjectUser projectUser = new ProjectUser()
            //{
            //    Name = "projectUser1",
            //    ProjectId = 1
            //};
            //projectUserService.Post(projectUser);
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
            using(StreamWriter sw = new StreamWriter(httpRequest.GetRequestStream()))
            {
                sw.Write(data);
            }
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
            return result; 
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