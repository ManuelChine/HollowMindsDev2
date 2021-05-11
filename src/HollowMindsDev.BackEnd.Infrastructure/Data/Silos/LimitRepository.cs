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
    public class LimitRepository : ILimitRepository
    {
        private readonly string _connectionString;

        public LimitRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public IEnumerable<Limit> GetAll()
        {
            const string query = @"
SELECT
    temperature as Temperature,
    pressure as Preassure,
    level_max as LevelMax,
    level_min as LevelMin,
    umidity as Umidity,
    material as Material
FROM limit_silo;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Limit>(query);
        }

        public Limit GetById(int id)
        {
            const string query = @"
SELECT
    temperature as Temperature,
    pressure as Preassure,
    level_max as LevelMax,
    level_min as LevelMin,
    umidity as Umidity,
    material as Material
FROM limit_silo
WHERE idLimit = @idL";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Limit>(query, new { idL = id });
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE FROM limit_silo
WHERE idLimit = @idL;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { idL = id });
        }

        public void Insert(Limit model)
        {
            const string query = @"
INSERT INTO limit_silo (temperature, umidity, pressure, level_max, level_min, material)
VALUES (@Temperature, @Umidity, @Pressure, @LevelMax, @LevelMin, @Material);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public Limit LimitBySilo(int idSilo)
        {
            const string query = @"
SELECT
    temperature as Temperature,
    pressure as Preassure,
    level_max as LevelMax,
    level_min as LevelMin,
    umidity as Umidity,
    material as Material
FROM limit_silo
INNER JOIN silo
ON limit_silo.idLimit = silo.idLimit
WHERE silo.idSilo = @idSilo";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Limit>(query, idSilo);
        }

        public void Update(Limit model)
        {
            const string query = @"
UPDATE limit_silo
SET temperature = @Temperature,
    pressure = @Pressure,
    level_max = @LevelMax,
    level_min = @LevelMin,
    umidity =  @Umidity,
    material = @Material
WHERE idLimit = @Id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }
    }
}
