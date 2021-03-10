using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Data.Interface
{
    public interface IDbContext
    {
        int SaveChanges();

       
    }
}
