using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Model.Response
{
   public  class DeleteResponse
    {
        public string Errormessage { get; set; }
        public bool deleted { get; set; }
    }
}
