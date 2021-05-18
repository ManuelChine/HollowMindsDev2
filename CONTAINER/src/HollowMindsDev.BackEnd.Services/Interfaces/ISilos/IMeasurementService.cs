using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.ISilos
{
    public interface IMeasurementService
    {
        IEnumerable<Measurement> GetAllMeasurement();
        Measurement GetByIdMeasurement(int id);
        void InsertMeasurement(Measurement model);
        void UpdateMeasurement(Measurement model);
        void DeleteMeasurement(int id);
        //restituisce l'ultima misurazione per ogni silo
        IEnumerable<Measurement> GetLastMeasurement();
        //restitiusce le luitime N misurazioni di 1 silo
        IEnumerable<Measurement> GetManyMeasurBySilo(int n, int idSilo);
        //misurazione ad una determinata ora
        IEnumerable<Measurement> GetMeasurByTime(DateTime time);
        //query che restituisce i dati di silo, limit, block e dell'ultima misurazione fatta in innner join di 1 solo silo
    
    }
}
