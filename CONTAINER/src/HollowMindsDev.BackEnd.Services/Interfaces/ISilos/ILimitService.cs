using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.ISilos
{
    public interface ILimitService
    {
        IEnumerable<Limit> GetAllLimit();
        Limit GetByIdLimit(int id);
        void InsertLimit(Limit model);
        void UpdateLimit(Limit model);
        void DeleteLimit(int id);
        //dato l'id del silo restituisce l'istanza limit corrispondente
        Limit LimitBySilo(int idSilo);
    }
}
