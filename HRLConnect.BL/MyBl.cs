using HRLConnect.CoreObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLConnect.BL
{
    public class MyBl
    {
        IRepository repo;
        public MyBl(IRepository repo)
        {
            this.repo = repo;
        }
        public string Show()
        {
            return repo.MyData();
        }
    }
}
