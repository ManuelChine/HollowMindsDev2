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
    public class SiloService : ISiloService
    {
        private readonly ISiloRepository _siloRepository;

        public SiloService(ISiloRepository siloRepository)
        {
            _siloRepository = siloRepository;
        }
        public void DeleteSilo(int id)
        {
            _siloRepository.Delete(id);
        }

        public IEnumerable<Silo> GetAllSilo()
        {
            return _siloRepository.GetAll();
        }

        public Silo GetByIdSilo(int id)
        {
            return _siloRepository.GetById(id);
        }

        public void InsertSilo(Silo model)
        {
            _siloRepository.Insert(model);
        }

        public void UpdateSilo(Silo model)
        {
            _siloRepository.Update(model);
        }
    }
}
