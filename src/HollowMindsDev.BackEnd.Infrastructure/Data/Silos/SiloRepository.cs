using Dapper;
using HollowMindsDev.BackEnd.ApplicationCore.Entities;
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
    public class SiloRepository : ISiloRepository
    {
        private readonly string _connectionString;

        public SiloRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }
        public void Delete(int id)
        {
            const string query = @"
DELETE FROM silo
WHERE idSilo = @idS;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { idS = id });
        }

        public IEnumerable<Silo> GetAll()
        {
            const string query = @"
SELECT
            idSilo as id,
            idBlock,
            idLimit,
            height as Height,
            diameter as Diameter,
            capacity as Capacity,
            year as YearProd,
            location as Location
            FROM silo;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Silo>(query);
        }

        public Silo GetById(int id)
        {
            const string query = @"
            SELECT
            idSilo as id,
            idBlock,
            idLimit,
            height as Height,
            diameter as Diameter,
            capacity as Capacity,
            year as YearProd,
            location as Location
            FROM silo
            WHERE idSilo = @idS;
            ";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Silo>(query, new { idS = id });
        }

        public void Insert(Silo model)
        {
            const string query = @"
INSERT INTO silo (idBlock, idLimit, height, diameter, capacity, year, location)
VALUES (@idBlock, @idLimit, @height, @diameter, @capacity, @year, @location);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public void Update(Silo model)
        {
            const string query = @"
UPDATE silo
SET idBlock = @idB, idLimit = @idL, height = @high, diameter = @diam, capacity = @cap, year_prod = @year, location = @loc, liquid = @liq
WHERE idSilo = @idS;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }
    }
}
