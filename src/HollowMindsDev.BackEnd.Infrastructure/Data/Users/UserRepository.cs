using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.IUsers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Infrastructure.Data.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE FROM user
WHERE idUser = @idU;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Execute(query, new { idU = id });
        }

        public IEnumerable<User> GetAll()//  !!! non implementatelo 
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            const string query = @"
SELECT
    idUser,
    mail,
    password,
    isAdmin,
    name,
    surname
FROM user
WHERE idUser = idU;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Execute(query, new { idU = id });
        }

        public bool IfIsAdmin(string mail)
        {
            throw new NotImplementedException();
        }

        public void Insert(User model)
        {
            throw new NotImplementedException();
        }

        public void Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
