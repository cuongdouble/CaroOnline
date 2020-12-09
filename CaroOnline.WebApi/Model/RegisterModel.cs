using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaroOnline.WebApi.Model
{
    public class RegisterModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Firstname { set; get; }
        public string Lastname { set; get; }
    }
    public class RegisterAdminModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
    }
}
