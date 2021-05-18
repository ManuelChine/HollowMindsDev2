using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Interfaces.IUsers
{
    public interface IAdminRepository : IRepository<Admin, int>
    {
        //la query mi restituisce le mail data quella inserita, poi è il metodo a restituire un bool in base se la mail è stata trovata o no
        bool IfIsAdmin(string mail);
    }
}
