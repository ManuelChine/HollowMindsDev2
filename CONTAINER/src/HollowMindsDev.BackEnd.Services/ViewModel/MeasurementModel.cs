using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.ViewModel
{
    public class MeasurementModel
    {
        public Measurement Measurement { get; set; }
        public Silo Silo { get; set; }
        public Limit Limit { get; set; }
        public Block Block { get; set; }
    }
}
