using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Interfaces.ISilos
{
    public interface IMeasurementRepository : IRepository<Measurement, int>
    {
        //restituisce l'ultima misurazione per ogni silo
        IEnumerable<Measurement> GetLastMeasurement();

        //restitiusce le ultime N misurazioni di 1 silo
        IEnumerable<Measurement> GetManyMeasurBySilo(int n, int idSilo);//opzionale

        //misurazione ad una determinata ora
        IEnumerable<Measurement> GetMeasurByTime(DateTime time);//opzionale
    }
}
