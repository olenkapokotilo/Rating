using Domain.Repositories.Interfaces;
using AutoMapper;
using Rating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Rating.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;
        
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        // GET: Project
        public ActionResult List()
        {
            return View( _projectRepository.GetAllProject().Select(p=> ProjectModel.FromDomainModel(p)));
        }
        public ActionResult Edit(int id) 
        {
            return View(ProjectModel.FromDomainModel(_projectRepository.GetProject(id)));
        }
        [HttpPost]
        public ActionResult Edit(ProjectModel project) 
        {   try
            {
                _projectRepository.Edit(Mapper.Map<Domain.Entities.Project>(project));
             }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
            return Redirect("/Project/List");
        }
        [Authorize]
        public ActionResult ProjectMenu()
        {
            int id = Convert.ToInt32(HttpContext.Request.Cookies["userId"].Value);
            return PartialView(_projectRepository.GetAllProjectByUserId(id).Select(p => ProjectModel.FromDomainModel(p)));
        }
        public ActionResult Create() 
        {

           //using (var client = new HttpClient())
           // {
           //     client.BaseAddress = new Uri("http://localhost:9000/");
           //     client.DefaultRequestHeaders.Accept.Clear();
           //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           //     // New code:
           //     HttpResponseMessage response = client.GetAsync("api/products/1").Result;
           //     if (response.IsSuccessStatusCode)
           //     {
           //         object product = response.Content.ReadAsStreamAsync().Result;
           //         Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
           //     }
           // }


            return View();
        }


        //public static WebResponse SendPostRequest(string data, string url)
        //{
        //    //Data parameter Example
        //    //string data = "name=" + value

        //    var httpRequest = HttpWebRequest.Create(url);
        //    httpRequest.Method = "POST";
        //    httpRequest.ContentType = "application/x-www-form-urlencoded";
        //    httpRequest.ContentLength = data.Length;

        //    var streamWriter = new StreamWriter(httpRequest.GetRequestStream());
        //    streamWriter.Write(data);
        //    streamWriter.Close();

        //    return httpRequest.GetResponse();
        //}

        //public static WebResponse SendGetRequest(string url)
        //{
        //    WebRequest httpRequest = HttpWebRequest.Create(url);
        //    httpRequest.Method = "GET";

        //    return httpRequest.GetResponse();
        //}


        [HttpPost]
        public ActionResult Create(ProjectModel newProject) 
        {
            try
            {
                newProject.UserId = Convert.ToInt32(HttpContext.Request.Cookies["userId"].Value);
                _projectRepository.Create(newProject.ToDomainModel());
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
            return Redirect("/Project/List");
        }

        public ActionResult Delete(int id)
        {
            _projectRepository.Delete(id);
            return Redirect("~/Project/List/");
        }
    }
}