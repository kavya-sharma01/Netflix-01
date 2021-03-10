using Netflix.Data.Interface;
using Netflix.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Netflix.Data;

namespace Netflix.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        /* private readonly INetflixDbContext _netflixDbContext;
         public AuthenticationService(INetflixDbContext netflixDbContext)
         {
             _netflixDbContext = netflixDbContext;
         }*/

       

        /*public Users ValidateEmailAndPassword(string email, string ps)
        {

           var userlist :iQueryable<Users> = _netflixDbContext.Users//DbSet<Users>
                .Where(x: Users => x.Email == email && x.Password == ps);
            return null;
        }*/

        bool IAuthenticationService.ValidateEmailAndPassword(string email, string ps)
        {
            throw new NotImplementedException();
        }

        public bool ValidateEmailAndPassword(string email, string ps)
        {
            var _email = "ks@gmail.com";
            var _ps = "yeuer";
            if (email == _email && ps == _ps)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public List<Users> GetUser(string firstname, int Page, int PageSize)
        {
            throw new NotImplementedException();
        }*/
    }
}
    
        /*public List<Users> GetUser(int Page, int PageSize=3)
        {
            var countTotalRecord; int _netflixdbContext.Users;
            
            return = _netflixDbContext.Users;//<DbSet<Users>
            .Skip(((Page-1)* PageSize )+1).Take(PageSize);
                      
        }*/

       
    

