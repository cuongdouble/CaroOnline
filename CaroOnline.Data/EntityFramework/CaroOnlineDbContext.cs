using CaroOnline.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaroOnline.Data.EntityFramework
{
    public class CaroOnlineDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public CaroOnlineDbContext(DbContextOptions<CaroOnlineDbContext> options):base(options)
        {

        }
    }
}
