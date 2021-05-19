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
    public class LimitService : ILimitService
    {
        private readonly ILimitRepository _limitRepository;

        public LimitService(ILimitRepository limitRepository)
        {
            _limitRepository = limitRepository;
        }
        public void DeleteLimit(int id)
        {
            _limitRepository.Delete(id);
        }

        public IEnumerable<Limit> GetAllLimit()
        {
            return _limitRepository.GetAll();
        }

        public Limit GetByIdLimit(int id)
        {
            return _limitRepository.GetById(id);
        }

        public void InsertLimit(Limit model)
        {
            _limitRepository.Insert(model);
        }

        public Limit LimitBySilo(int idSilo)
        {
            return _limitRepository.LimitBySilo(idSilo);
        }

        public void UpdateLimit(Limit model)
        {
            _limitRepository.Update(model);
        }
    }
}
