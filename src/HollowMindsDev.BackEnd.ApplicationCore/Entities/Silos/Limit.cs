using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos
{
    public class Limit : Entity<int>
    {
        public decimal Temperature { get; set; }
        public decimal Preassure { get; set; }
        public int LevelMax { get; set; }
        public int LevelMin { get; set; }
        public decimal Umidity { get; set; }
        public string Material { get; set; }
    }
}
