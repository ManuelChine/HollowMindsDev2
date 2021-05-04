using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos
{
    public class Measurement : Entity<int>
    {
        public bool Sensor0 { get; set; }
        public bool Sensor1 { get; set; }
        public bool Sensor2 { get; set; }
        public bool Sensor3 { get; set; }
        public bool Sensor4 { get; set; }
        public bool Sensor5 { get; set; }
        public bool Sensor6 { get; set; }
        public bool Sensor7 { get; set; }
        public decimal Pressure { get; set; }
        public decimal Density { get; set; }
        public decimal TemperatureTop { get; set; }
        public decimal TemperatureBottom { get; set; }
        public decimal UmidityTop { get; set; }
        public decimal UmidityBottom { get; set; }
        public DateTime Time { get; set; }

        public byte DropCheck { get; set; }

        //FK
        public int IdSilo { get; set; }
    }
}
