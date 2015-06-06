using AutoMapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FileRepository
    {
        public Domain.Entities.File GetFile(int id)
        {
            using (var entities = new Entities())
            {
                var file = entities.File.SingleOrDefault(at => at.Id == id);
                var result = Mapper.Map<Domain.Entities.File>(file);
                return result;
            }
        }
        public void Create(Domain.Entities.File file) 
        {
            using (var entities = new Entities())
            {
                entities.File.Add(Mapper.Map<DataAccess.Model.File>(file));
                entities.SaveChanges();
            }  
        }
        public void Delete(int id) 
        {
            using (var entities = new Entities())
            {
                var file = this.GetFile(id);
                entities.Entry(Mapper.Map<DataAccess.Model.File>(file)).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }
    }
}
