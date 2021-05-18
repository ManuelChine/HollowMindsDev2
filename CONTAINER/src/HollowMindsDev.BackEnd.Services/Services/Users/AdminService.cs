using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.IUsers;
using HollowMindsDev.BackEnd.Services.Interfaces.IUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Services.Users
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public void DeleteAdmin(int id)
        {
            _adminRepository.Delete(id);
        }

        public IEnumerable<Admin> GetAllAdmin()
        {
            return _adminRepository.GetAll();
        }

        public Admin GetByIdAdmin(int id)
        {
            return _adminRepository.GetById(id);
        }

        public bool IfIsAdmin(string mail)
        {
            return _adminRepository.IfIsAdmin(mail);
        }

        public void InsertAdmin(Admin model)
        {
            _adminRepository.Insert(model);
        }

        public void UpdateAdmin(Admin model)
        {
            _adminRepository.Update(model);
        }
    }
}
