using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Users
{
    public class Admin: Entity<int>
    {
        public string mail { get; set; }
    }
}
