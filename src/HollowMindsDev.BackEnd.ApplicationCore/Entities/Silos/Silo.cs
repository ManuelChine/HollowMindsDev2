using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos
{
    public class Silo : Entity<int>
    {
        public decimal Height { get; set; }
        public decimal Diameter { get; set; }
        public decimal Capacity { get; set; }
        public int YearProd { get; set; }
        public string Location { get; set; }

        //FK
        public int IdBlock { get; set; }
        public int IdLimit { get; set; }
    }
}
