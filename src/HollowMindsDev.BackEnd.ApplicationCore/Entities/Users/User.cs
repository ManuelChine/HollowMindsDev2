using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Users
{
    public class User: Entity<int>
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [StringLength(100)]
        public string Mail { get; set; }

        [Required]
        [StringLength(100)]

        public string Password { get; set; }

        [Required]
        [Range(0, 1)]
        public byte IsAdmin { get; set; }
    }
}
