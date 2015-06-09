using AutoMapper;
using DataAccess.Model;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FileRepository : IFileRepository

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
        public int Create(byte[] image) 
        {
            using (var entities = new Entities())
            {
                var file = new File();
                file.Image = image;
                var newFile = entities.File.Add(Mapper.Map<DataAccess.Model.File>(file));
                entities.SaveChanges();
                return newFile.Id;
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
