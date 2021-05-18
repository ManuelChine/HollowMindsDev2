using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.ISilos;
using HollowMindsDev.BackEnd.Services.Interfaces.ISilos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Services.Silos
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;

        public BlockService(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public Block BlockBySilo(int idSilo)
        {
            return _blockRepository.BlockBySilo(idSilo);
        }

        public void DeleteBlock(int id)
        {
            _blockRepository.Delete(id);
        }

        public IEnumerable<Block> GetAllBlock()
        {
            return _blockRepository.GetAll();
        }

        public Block GetByIdBlock(int id)
        {
            return _blockRepository.GetById(id);
        }

        public void InsertBlock(Block model)
        {
            _blockRepository.Insert(model);
        }

        public void UpdateBlock(Block model)
        {
            _blockRepository.Update(model);
        }
    }
}
