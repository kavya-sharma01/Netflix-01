using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Model.Response
{
    public class UserResponse<T>
    {
        public int Totalpage { get; set; }

        public int Currentpage { get; set; }
        public int pagesize { get; set; }
        public List<T> Data { get; set; }

    }
}
