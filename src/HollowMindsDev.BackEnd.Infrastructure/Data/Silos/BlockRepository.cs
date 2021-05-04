using Dapper;
using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.ISilos;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Infrastructure.Data.Silos
{
    public class BlockRepository : IBlockRepository
    {

        private readonly string _connectionString;

        public BlockRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public IEnumerable<Block> GetAll()
        {
            const string query = @"
SELECT
    name as Name
FROM block;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Block>(query);
        }

        public Block GetById(int id)
        {
            const string query = @"
SELECT
    name as Name
FROM block
WHERE idBlock = @idB;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Block>(query, new { id });
        }

        public Block BlockBySilo(int idSilo)
        {
            const string query = @"
SELECT
    name
FROM block
INNER JOIN silo
ON block.idBlock = silo.idBlock
WHERE silo.idSilo = @idS;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Block>(query, new { idS = idSilo });
        }

        public void Delete(int id)
        {
            const string query = @"DELETE FROM block WHERE id = @id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { Id = id });
        }

        public void Insert(Block model)
        {
            const string query = @"
INSERT INTO tasks ( name as Name, )
VALUES (@Name);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public void Update(Block model)
        {
            const string query = @"
UPDATE block
SET Name = @Name
WHERE idBlock = @Id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }
    }
}
