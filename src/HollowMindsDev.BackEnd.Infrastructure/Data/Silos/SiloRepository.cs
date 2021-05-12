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
        public void Delete(int id)  //Query che elimina un elemento in base al id dato dall'utente
        {
            const string query = @"
DELETE FROM silo
WHERE idSilo = @idS;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { idS = id });
        }

        public IEnumerable<Silo> GetAll() //Query che fa visualizzare tutti gli elementi presenti nella tabella
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

        public Silo GetById(int id) //Query utilizzata per visualizzare un singolo elemento in base all'id inserito dall'utente
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
            WHERE idSilo = @idSilo;
            ";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Silo>(query, new { idSilo = id });
        }

        public void Insert(Silo model) //Query per inserire un nuovo elemento
        {
            const string query = @"
INSERT INTO silo (idBlock, idLimit, height, diameter, capacity, year, location)
VALUES (@IdBlock, @IdLimit, @Height, @Diameter, @Capacity, @Year, @Location);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public void Update(Silo model)
        {
            throw new NotImplementedException();
        }
    }
}
