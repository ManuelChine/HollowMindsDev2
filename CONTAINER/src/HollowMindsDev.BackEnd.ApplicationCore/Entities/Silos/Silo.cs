using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos
{
    public class Silo : Entity<int>
    {
        [Required]
        [Range(5, 30,
            ErrorMessage = "Value For Height must be between {0}m and {1}m.")]
        [DataType(DataType.Currency)]
        public decimal Height { get; set; }

        [Required]
        [Range(1, 30,
            ErrorMessage = "Value For Height must be between {0}m and {1}m.")]
        [DataType(DataType.Currency)]
        public decimal Diameter { get; set; }

        [Required]
        [Range(10,10000,
            ErrorMessage = "Value For Height must be between {0}l and {1}l.")]
        [DataType(DataType.Currency)]
        public decimal Capacity { get; set; }

        [Required]
        [Range(1970, 3000,
            ErrorMessage = "Value For Height must be between {0} and {1}.")]
        public int YearProd { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Location { get; set; }

        //FK

        [Required]
        public int IdBlock { get; set; }

        [Required]
        public int IdLimit { get; set; }
    }
}
