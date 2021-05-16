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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        public User GetByIdUser(int id)
        {
            return _userRepository.GetById(id);
        }

        public bool IfIsAdmin(string mail)
        {
            return _userRepository.IfIsAdmin(mail);
        }

        public void InsertUser(User model)
        {
            _userRepository.Insert(model);
        }

        public void UpdateUser(User model)
        {
            _userRepository.Update(model);
        }
    }
}
