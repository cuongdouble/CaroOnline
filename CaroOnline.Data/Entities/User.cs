using System;
using System.Collections.Generic;
using System.Text;

namespace CaroOnline.Data.Entities
{
    public class User
    {
        public Guid Id { set; get; }
        public string Username { set; get; }
        public string Firstname { set; get; }
        public string Lastname { set; get; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
