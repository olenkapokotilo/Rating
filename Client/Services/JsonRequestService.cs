using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client.Services
{
    public class JsonRequestService<T> : IRequestService<T> where T: class
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
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create(path);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json; charset=utf-8";
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
            httpRequest.Method = "GET";
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
                byte[] bytes = Convert.FromBase64String(jsonContent);
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
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}