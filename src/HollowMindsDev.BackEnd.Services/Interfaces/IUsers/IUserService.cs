using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.IUsers
{
    public interface IUserService
    {
        User GetByIdUser(int id);
        void InsertUser(User model);
        void UpdateUser(User model);
        void DeleteUser(int id);
        //la query mi restituisce le mail data quella inserita, poi è il metodo a restituire un bool in base se la mail è stata trovata o no
        bool IfIsAdmin(string mail);
    }
}
