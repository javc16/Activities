using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activities.Models
{
    public class Citizen
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int IdNativeCity { get; set; }
        public NativeCity NativeCity { get; set; }

    }
}
