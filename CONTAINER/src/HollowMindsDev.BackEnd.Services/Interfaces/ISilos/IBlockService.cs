using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.ISilos
{
    public interface IBlockService
    {
        IEnumerable<Block> GetAllBlock();
        Block GetByIdBlock(int id);
        void InsertBlock(Block model);
        void UpdateBlock(Block model);
        void DeleteBlock(int id);
        //dato l'id del silo restituisce l'istanza Block corrispondente
        Block BlockBySilo(int idSilo);
    }
}
