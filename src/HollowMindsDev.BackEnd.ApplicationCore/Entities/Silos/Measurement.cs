using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos
{
    public class Measurement : Entity<int>
    {
        [Required]
        [Range(0, 1)]
        public bool Sensor0 { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Sensor1 { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Sensor2 { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Sensor3 { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Sensor4 { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Sensor5 { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Sensor6 { get; set; }

        [Required]
        [Range(0, 1)]
        public bool Sensor7 { get; set; }

        [Required]
        [Range(0.5, 10,
            ErrorMessage = "Value For Pressure must be between {0} and {1}.")]
        [DataType(DataType.Currency)]

        public decimal Pressure { get; set; }

        [Range(0, 100,
            ErrorMessage = "Value For Density must be between {0}Kg/m3 and {1}Kg/m3.")]
        [DataType(DataType.Currency)]
        public decimal Density { get; set; }

        [Required]
        [Range(-30, 100,
            ErrorMessage = "Value For Temperature must be between {0}°C and {1}°C.")]
        [DataType(DataType.Currency)]
        public decimal TemperatureTop { get; set; }

        [Required]
        [Range(-30, 100,
            ErrorMessage = "Value For Temperature must be between {0}°C and {1}°C.")]
        [DataType(DataType.Currency)]
        public decimal TemperatureBottom { get; set; }

        [Required]
        [Range(0, 100,
            ErrorMessage = "Value For Umidity must be between {0}% and {1}%.")]
        [DataType(DataType.Currency)]
        public decimal UmidityTop { get; set; }

        [Required]
        [Range(0, 100,
            ErrorMessage = "Value For Umidity must be between {0}% and {1}%.")]
        [DataType(DataType.Currency)]
        public decimal UmidityBottom { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [Required]
        public byte DropCheck { get; set; }

        //FK
        [Required]
        public int IdSilo { get; set; }
    }
}
