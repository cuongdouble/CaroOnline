using System;
using System.Collections.Generic;
using System.Text;

namespace CaroOnline.Data.Entities
{
    public class Admin
    {
        public Guid Id { set; get; }
        public string Username { set; get; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
