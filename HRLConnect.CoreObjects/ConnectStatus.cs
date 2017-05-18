using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.CoreObjects
{
    public class ConnectStatus
    {
        public int StatusId { get; set; }
        public string StatusText { get; set; }
        public int? NextStatusId { get; set; }
        public string NextStatusText { get; set; }
    }
}
