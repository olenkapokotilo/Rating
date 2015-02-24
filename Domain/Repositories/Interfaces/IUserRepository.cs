using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUserByEmail(string email);

        List<User> GetAllUsers();
        void Add(User user);
        void SaveChanges();
        void ChangePassword(string newPassword, string newRepeatPassword, string Email);
    }
}
