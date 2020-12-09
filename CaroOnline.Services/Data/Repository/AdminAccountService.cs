using CaroOnline.Data.Entities;
using CaroOnline.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CaroOnline.Services.Data.PasswordHash.PasswordHash;

namespace CaroOnline.Services.Data.Repository
{
    public class AdminAccountService : IAdminAccountService
    {
        private readonly CaroOnlineDbContext _context;

        public AdminAccountService(CaroOnlineDbContext context)
        {
            _context = context;
        }

        public Admin Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var admin = _context.Admins.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (admin == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt))
                return null;

            // authentication successful
            return admin;
        }

        public Admin Create(string username, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                return null;

            if (_context.Admins.Any(x => x.Username == username))
                return null;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var admin = new Admin() { Username = username };
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;
        }
    }
}
