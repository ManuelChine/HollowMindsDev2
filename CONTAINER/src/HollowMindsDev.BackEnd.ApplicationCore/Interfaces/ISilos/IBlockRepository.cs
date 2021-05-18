using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Interfaces.ISilos
{
    public interface IBlockRepository: IRepository<Block, int>
    {
        //dato l'id del silo restituisce l'istanza Block corrispondente
        Block BlockBySilo(int idSilo);
    }
}
