using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndActivitites.Helpers
{
    public class Response
    {
        public string Message { get; set; }
        public object Data { get; set; }

        public static implicit operator Response(string v)
        {
            throw new NotImplementedException();
        }

    }
}
