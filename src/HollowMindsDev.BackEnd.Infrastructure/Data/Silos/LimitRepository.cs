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
    temperature_max as TemperatureMax,
    temperature_min as TemperatureMin,
    pressure_max as PreassureMax,
    pressure_min as PreassureMin,
    level_max as LevelMax,
    level_min as LevelMin,
    umidity_max as UmidityMax,
    umidity_min as UmidityMin,
    material as Material
FROM limit_silo;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Limit>(query);
        }

        public Limit GetById(int id)
        {
            const string query = @"
SELECT
    temperature_max as TemperatureMax,
    temperature_min as TemperatureMin,
    pressure_max as PreassureMax,
    pressure_min as PreassureMin,
    level_max as LevelMax,
    level_min as LevelMin,
    umidity_max as UmidityMax,
    umidity_min as UmidityMin,
    material as Material
FROM limit_silo
WHERE idLimit = @idL";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Limit>(query, new { id });
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE FROM limit
WHERE idLimit = @idL;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { idL = id });
        }

        public void Insert(Limit model)
        {
            throw new NotImplementedException();
        }

        public Limit LimitBySilo(int idSilo)
        {
            const string query = @"
SELECT
    temperature_max as TemperatureMax,
    temperature_min as TemperatureMin,
    pressure_max as PreassureMax,
    pressure_min as PreassureMin,
    level_max as LevelMax,
    level_min as LevelMin,
    umidity_max as UmidityMax,
    umidity_min as UmidityMin,
    material as Material
FROM limit_silo
INNER JOIN silo
ON limit_silo.idLimit = silo.idLimit
WHERE silo.idSilo = @idS";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Limit>(query, new { idSilo });
        }

        public void Update(Limit model)
        {
            throw new NotImplementedException();
        }
    }
}
