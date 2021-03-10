using Netflix.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Service
{
    public interface IAuthenticationService
    {
        bool ValidateEmailAndPassword(string email, string ps);
       // List<Users> GetUser(string firstname, int Page, int PageSize);
    }

}
