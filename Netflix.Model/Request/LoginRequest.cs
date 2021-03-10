using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Netflix.Model.Request
{
    public class LoginRequest
    {
     
        [Required]
        public string email { get; set; }
        public string ps { get; set; }
    }
}
