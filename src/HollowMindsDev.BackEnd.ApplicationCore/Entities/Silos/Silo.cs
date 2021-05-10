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
        public decimal Height { get; set; }

        [Required]
        public decimal Diameter { get; set; }

        [Required]
        public decimal Capacity { get; set; }

        [Required]
        public int YearProd { get; set; }

        [Required]
        public string Location { get; set; }

        //FK

        [Required]
        public int IdBlock { get; set; }

        [Required]
        public int IdLimit { get; set; }
    }
}
