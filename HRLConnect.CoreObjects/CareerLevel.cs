using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    public class CareerLevel
    {
        public int CLID { get; set; }
        public string CareerLev { get; set; }
        public bool CanConnect { get; set; }
        public int Hierarchy { get; set; }
    }
}
