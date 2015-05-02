using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
        public interface IRequestService<T> where T: class
        {
            void Post(T data);
            string Get();
            void Put(T data);
            void Delete(int id);
        }
}
