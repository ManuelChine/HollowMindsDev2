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
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly string _connectionString;

        public MeasurementRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }
        public void Delete(int id) //Query che elimina un elemento in base al id dato dall'utente
        {
            const string query = @"
DELETE FROM measurement
WHERE idMeasurement = @idM;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, new { idM = id });
        }

        public IEnumerable<Measurement> GetAll() //Query che fa visualizzare tutti gli elementi presenti nella tabella
        {
            const string query = @"
SELECT
    sensor0 as Sensor0,
    sensor1 as Sensor1,
    sensor2 as Sensor2,
    sensor3 as Sensor3,
    sensor4 as Sensor4,
    sensor5 as Sensor5,
    sensor6 as Sensor6,
    sensor7 as Sensor7,
    pressure as Pressure,
    density as Density,
    temperature_top as TemperatureTop,
    temperature_bottom as TemperatureBottom,
    umidity_top as UmidityTop,
    umidity_bottom as UmidityBottom,
    timeInsert as Time,
    dropcheck as DropCheck
FROM measurement;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Measurement>(query);
        }

        public Measurement GetById(int id) //Query utilizzata per visualizzare un singolo elemento in base all'id inserito dall'utente
        {
            const string query = @"
SELECT
    sensor0 as Sensor0,
    sensor1 as Sensor1,
    sensor2 as Sensor2,
    sensor3 as Sensor3,
    sensor4 as Sensor4,
    sensor5 as Sensor5,
    sensor6 as Sensor6,
    sensor7 as Sensor7,
    pressure as Pressure,
    density as Density,
    temperature_top as TemperatureTop,
    temperature_bottom as TemperatureBottom,
    umidity_top as UmidityTop,
    umidity_bottom as UmidityBottom,
    timeInsert as Time,
    dropcheck as DropCheck
FROM measurement
WHERE idMeasurement = @idM;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Measurement>(query, new { idM = id});
        }

        public IEnumerable<Measurement> GetLastMeasurement() //Query utilizzata per visualizzare l'ultima misurazione di ogni silo
        {
            const string query = @"
            SELECT
measurement.idMeasurement as Id,
measurement.sensor0 as Sensor0,
measurement.sensor1 as Sensor1,
measurement.sensor2 as Sensor2,
measurement.sensor3 as Sensor3,
measurement.sensor4 as Sensor4,
measurement.sensor5 as Sensor5,
measurement.sensor6 as Sensor6,
measurement.sensor7 as Sensor7,
measurement.pressure as pressure,
measurement.density as density,
measurement.temperature_top as temperatureTop,
measurement.temperature_bottom as temperatureBottom,
measurement.umidity_top as umidityTop,
measurement.umidity_bottom as umidityBottom,
measurement.timeInsert as time,
measurement.dropcheck as dropcheck,
measurement.idSilo as idSilo
FROM
silo inner join limit_silo on limit_silo.idLimit = silo.idLimit
inner join block on block.idBlock = silo.idBlock
inner join measurement on measurement.idSilo = silo.idSilo
WHERE measurement.idMeasurement IN(SELECT MAX(idMeasurement)
                                     FROM measurement
                                     GROUP BY idSilo
                                     );";
            using var connection = new MySqlConnection(_connectionString);
            return connection.Query<Measurement>(query);
        }

        /*
         * 
        public Measurement GetLastMeasurementById(int idSilo)
        {
            const string query = @"
            SELECT
measurement.level as level,
measurement.pressure as pressure,
measurement.density as density,
measurement.temperature_top as temperatureTop,
measurement.temperature_bottom as temperatureBottom,
measurement.umidity_top as umidityTop,
measurement.umidity_bottom as umidityBottom,
measurement.timeInsert as time,
measurement.dropcheck as dropcheck
FROM
silo inner join limit_silo on limit_silo.idLimit = silo.idLimit
inner join block on block.idBlock = silo.idBlock
inner join measurement on measurement.idSilo = silo.idSilo
WHERE measurement.idMeasurement IN(SELECT idMeasurement
                                     FROM measurement
                                     GROUP BY idSilo
                                     HAVING time = MAX(time)
                                     )
AND measurement.idSilo = @idSilo;";
            using var connection = new MySqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Measurement>(query, new { idSilo } );
        }*/

        public IEnumerable<Measurement> GetManyMeasurBySilo(int n, int idSilo) //optional
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Measurement> GetMeasurByTime(DateTime time) //optional
        {
            throw new NotImplementedException();
        }

        public void Insert(Measurement model)   //Query per inserire un nuovo elemento
        {
            const string query = @"
INSERT INTO measurement ( sensor0, sensor1, sensor2, sensor3, sensor4, sensor5, sensor6, sensor7, pressure, density, temperature_top, temperature_bottom, umidity_top, umidity_bottom, timeInsert, dropcheck, idSilo)
VALUES (@Sensor0, @Sensor1, @Sensor2, @Sensor3, @Sensor4, @Sensor5, @Sensor6, @Sensor7, @Pressure, @Density, @TemperatureTop, @TemperatureBottom, @UmidityTop, @UmidityBottom, @Time, @DropCheck, @IdSilo);";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }

        public void Update(Measurement model)   //Query utilizzata per modificare un determinato elemento in base all'id indicato dall'utente
        {
            const string query = @"
UPDATE measurement
SET sensor0 = @Sensor0,
    sensor1 = @Sensor1, 
    sensor2 = @Sensor2, 
    sensor3 = @Sensor3, 
    sensor4 = @Sensor4, 
    sensor5 = @Sensor5, 
    sensor6 = @Sensor6, 
    sensor7 = @Sensor7, 
    pressure = @Pressure, 
    density  = @Density,
    temperature_top = @TemperatureTop, 
    temperature_bottom = @TemperatureBottom, 
    umidity_top = @UmidityTop,
    umidity_bottom = @UmidityBottom, 
    timeInsert = @Time,
    dropcheck = @DropCheck
WHERE idMeasurement = @Id;";
            using var connection = new MySqlConnection(_connectionString);
            connection.Execute(query, model);
        }
    }
}