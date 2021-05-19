using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.IUsers
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAllAdmin();
        Admin GetByIdAdmin(int id);
        void InsertAdmin(Admin model);
        void UpdateAdmin(Admin model);
        void DeleteAdmin(int id);
        //la query mi restituisce le mail data quella inserita, poi è il metodo a restituire un bool in base se la mail è stata trovata o no
        bool IfIsAdmin(string mail);
    }
}
