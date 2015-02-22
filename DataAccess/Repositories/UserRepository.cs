using AutoMapper;
using DataAccess.Model;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        
        public Domain.Entities.User GetUser(int id)
        {
            using(var entities =  new Entities())
            {
                var dbUser = entities.User.Single(u => u.Id == id);
                var result = Mapper.Map<Domain.Entities.User>(dbUser);
                return result;
            }
        }

        public Domain.Entities.User GetUserByEmail(string email)
        {
            using (var entities = new Entities())
            {
                var dbUser = entities.User.Single(u => u.Email == email);
                var result = Mapper.Map<Domain.Entities.User>(dbUser);
                return result;
            }
        }
        public List<Domain.Entities.User> GetAllUsers()
        {
            using(var entities = new Entities())
            {
                var dbUsers = entities.User.ToList();
                IEnumerable<Domain.Entities.User> result = Mapper.Map<IEnumerable<Domain.Entities.User>>(dbUsers);
                return result.ToList();
            }
        }
    }
}
