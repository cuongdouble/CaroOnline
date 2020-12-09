using CaroOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaroOnline.Services.Data.Repository
{
    public interface  IUserAccountService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        bool Update(User user, string password = null);
        bool Delete(int id);
    }
}
