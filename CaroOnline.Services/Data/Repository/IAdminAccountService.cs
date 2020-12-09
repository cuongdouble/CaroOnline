using CaroOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaroOnline.Services.Data.Repository
{
    public interface IAdminAccountService
    {
        Admin Authenticate(string username, string password);
        Admin Create(string username, string password);

    }
}
