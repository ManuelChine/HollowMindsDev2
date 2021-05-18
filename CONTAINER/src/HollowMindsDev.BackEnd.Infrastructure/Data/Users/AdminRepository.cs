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
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE FROM administrator
WHERE idAdmin = @idA;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { idA = id });
        }

        public IEnumerable<Admin> GetAll()
        {
            const string query = @"
SELECT
    mail as EMail
FROM administrator;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Admin>(query);
        }

        public Admin GetById(int id)
        {
            const string query = @"
SELECT
    mail as EMail
FROM administrator
WHERE idAdmin = @idA;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Admin>(query);
        }

        public bool IfIsAdmin(string mail) //Opzionale
        {
            //int x = 2;
            return true;
        }

        public void Insert(Admin model)
        {
            const string query = @"
INSERT INTO administrator (mail)
VALUES (@email);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public void Update(Admin model)
        {
            const string query = @"
UPDATE administrator
SET mail = @email
WHERE idAdmin = @Id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }
    }
}
