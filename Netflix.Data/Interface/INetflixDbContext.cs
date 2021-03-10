using Microsoft.EntityFrameworkCore;
using Netflix.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Data.Interface
{
  public   interface INetflixDbContext : IDisposable, IDbContext
    {
        DbSet<Users> Users { get; set; }



        
    }
}
