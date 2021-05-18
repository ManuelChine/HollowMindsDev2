using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.ISilos
{
    public interface ISiloService
    {
        IEnumerable<Silo> GetAllSilo();
        Silo GetByIdSilo(int id);
        void InsertSilo(Silo model);
        void UpdateSilo(Silo model);
        void DeleteSilo(int id);
        
    }
}
