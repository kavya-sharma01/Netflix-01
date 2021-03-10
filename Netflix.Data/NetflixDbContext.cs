using Microsoft.EntityFrameworkCore;
using Netflix.Data.Interface;
using Netflix.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Data
{
   public class NetflixDbContext: DbContext, INetflixDbContext
    {
        public DbSet<Users> Users { get; set; }
        

        public NetflixDbContext()
        {

        }
        public NetflixDbContext(DbContextOptions<NetflixDbContext> options) : base(options)
        {
           

        }

       
    }
}
