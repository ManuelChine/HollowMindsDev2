using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos
{
    public class Limit : Entity<int>
    {
        [Range(-30, 100,
            ErrorMessage = "Value For Temperature must be between {0}°C and {1}°C.")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Temperature { get; set; }

        [Range(0.5, 10 ,
            ErrorMessage = "Value For Pressure must be between {0} and {1}.")]
        [Required]
        [DataType(DataType.Currency)]

        public decimal Pressure { get; set; }

        [Required]
        public int LevelMax { get; set; }

        [Required]
        public int LevelMin { get; set; }

        [Range(0, 100,
            ErrorMessage = "Value For Umidity must be between {0}% and {1}%.")]
        [Required]
        [DataType(DataType.Currency)]

        public decimal Umidity { get; set; }

        [StringLength(30)]
        [Required]
        public string Material { get; set; }
    }
}
