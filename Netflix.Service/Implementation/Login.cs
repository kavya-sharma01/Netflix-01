using Netflix.Data.Interface;
using Netflix.Model.Models;
using Netflix.Model.Request;
using Netflix.Model.Response;
using Netflix.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netflix.Service.Implementation
{
    public class Login : ILogin
    {
        private INetflixDbContext _netflixdbcontext;
        public Login(INetflixDbContext netflixdbcontext)
        {
            _netflixdbcontext = netflixdbcontext;
        }


        public LoginResponse LoginProcess(LoginRequest request)
        {
            // if (_netflixdbcontext.Users.Any(o => o.Email == request.Email && o.Password == request.Password))
            //{
            //   return true;
            //}
            //else
            //{
            //   return false;
            //}

           
            var Users = _netflixdbcontext.Users.Where(o => o.email == request.email).FirstOrDefault();
            if (Users != null)
            {
                if (Users.ps.Equals(request.ps))
                    return new LoginResponse { IsLoginSuccess = true };
                else
                    return new LoginResponse { IsLoginSuccess = false, Error = "Password Incorrect" };
            }
            
            return new LoginResponse { Error = "Email did not matched in records"};
        }
    }
}
