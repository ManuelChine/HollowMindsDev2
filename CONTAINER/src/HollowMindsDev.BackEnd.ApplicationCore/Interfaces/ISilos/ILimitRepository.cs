using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Interfaces.ISilos
{
    public interface ILimitRepository : IRepository<Limit, int>
    {
        //dato l'id del silo restituisce l'istanza limit corrispondente
        Limit LimitBySilo(int idSilo);
    }
}
