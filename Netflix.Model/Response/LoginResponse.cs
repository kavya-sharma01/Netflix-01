using Netflix.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Model.Response
{
    public class LoginResponse
    {
        public bool IsLoginSuccess { get; set; }
        public string Error { get; set; }

       public Users Users { get; set; }

       
    }
}
