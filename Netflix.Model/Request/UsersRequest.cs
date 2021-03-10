using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Model.Request
{
    public class UsersRequest
    {

        public int id { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string ps { get; set; }
        public int no { get; set; }
        public string course { get; set; }
        public bool checkbox { get; set; }
    }
}

