using Dapper;
using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.IUsers;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
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
            connection.Execute(query, new { idU = id });
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
WHERE idUser = @idU;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<User>(query, new { idU = id });
        }

        public bool IfIsAdmin(string mail)
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
WHERE isUser = 1;";
            return true; //da completare
        }

        public void Insert(User model)
        {
            const string query = @"
INSERT INTO user (idUser, mail, password, isAdmin, name, surname)
VALUES (@IdUser, @Mail, @Password, @IsAdmin, @Name, @Surname);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public void Update(User model)
        {
            const string query = @"
UPDATE user
SET mail = @Mail,
    password = @Password,
    isAdmin = @IsAdmin,
    name = @Name,
    surname = @Surname
WHERE idUser = @Id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }
    }
}
