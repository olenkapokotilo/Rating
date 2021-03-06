﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ApiClient.Services
{
    public class JsonRequestService<T> : IRequestService<T> where T : class
    {
        private readonly string path;
        public JsonRequestService(string basePath)
        {
            this.path = basePath;
        
        }
        public void Post(T data)
        {
            string jsonContent = JsonConvert.SerializeObject(data);
            string result = string.Empty;
            var httpRequest = HttpWebRequest.Create(path);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            using (StreamWriter sw = new StreamWriter(httpRequest.GetRequestStream()))
            {
                sw.Write(jsonContent);
            }
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
        }

        public string Get()
        {
            string result = string.Empty;
            var httpRequest = HttpWebRequest.Create(path);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

        public void Put(T data)
        {
            string jsonContent = JsonConvert.SerializeObject(data);
            string result = string.Empty;
            var httpRequest = HttpWebRequest.Create(path);
            httpRequest.Method = "PUT";
            httpRequest.ContentType = "application/json";
            using (StreamWriter sw = new StreamWriter(httpRequest.GetRequestStream()))
            {
                sw.Write(jsonContent);
            }
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}