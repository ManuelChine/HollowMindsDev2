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

        public IEnumerable<Block> GetAll()  //Query che fa visualizzare tutti gli elementi presenti nella tabella
        {
            const string query = @"
SELECT
    name as Name
FROM block;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Block>(query);
        }

        public Block GetById(int id)    //Query utilizzata per visualizzare un singolo elemento in base all'id inserito dall'utente
        {
            const string query = @"
SELECT
    name as Name
FROM block
WHERE idBlock = @idB;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Block>(query, new { idB = id });
        }

        public Block BlockBySilo(int idSilo)    //Query utilizzata per vedere a che blocco appartiente un determinato silo in base all'id di quest'ultimo inserito dall'utente
        {
            const string query = @"
SELECT
    block.idBlock as Id, 
    name 
FROM block
INNER JOIN silo
ON block.idBlock = silo.idBlock
WHERE silo.idSilo = @idS;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Block>(query, new { idS = idSilo });
        }

        public void Delete(int id)  //Query che elimina un elemento in base al id dato dall'utente
        {
            const string query = @"DELETE FROM block WHERE idBlock = @id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { Id = id });
        }

        public void Insert(Block model) //Query per inserire un nuovo elemento
        {
            const string query = @"
INSERT INTO block (name)
VALUES (@Name);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public void Update(Block model) //Query utilizzata per modificare un determinato elemento in base all'id indicato dall'utente
        {
            const string query = @"
UPDATE block
SET name = @Name
WHERE idBlock = @Id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }
    }
}
