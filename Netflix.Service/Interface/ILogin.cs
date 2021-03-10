using Netflix.Model.Models;
using Netflix.Model.Request;
using Netflix.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Service.Interface
{
  public  interface ILogin
    {
       LoginResponse LoginProcess(LoginRequest request);
    }
}
