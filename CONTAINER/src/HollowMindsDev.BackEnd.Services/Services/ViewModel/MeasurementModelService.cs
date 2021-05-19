using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.ISilos;
using HollowMindsDev.BackEnd.Services.Interfaces.ViewModel;
using HollowMindsDev.BackEnd.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Services.ViewModel
{
    public class MeasurementModelService: IMeasurementModelService
    {
        private readonly ISiloRepository _siloRepository;
        private readonly ILimitRepository _limitRepository;
        private readonly IBlockRepository _blockRepository;
        private readonly IMeasurementRepository _measurementRepository;

        public MeasurementModelService(ISiloRepository siloRepository, ILimitRepository limitRepository, IBlockRepository blockRepository, IMeasurementRepository measurementRepository)
        {
            _siloRepository = siloRepository;
            _limitRepository = limitRepository;
            _blockRepository = blockRepository;
            _measurementRepository = measurementRepository;
        }

        public List<MeasurementModel> GetAllModel()
        {
            List<MeasurementModel> lista = new List<MeasurementModel>();
            var measurs = _measurementRepository.GetLastMeasurement();
            foreach (var item in measurs)
            {
                MeasurementModel element = new MeasurementModel();
                element.Measurement = item;
                element.Silo = _siloRepository.GetById(item.IdSilo);
                element.Limit = _limitRepository.LimitBySilo(item.IdSilo);
                element.Block = _blockRepository.BlockBySilo(item.IdSilo);
                lista.Add(element);
            }
            return lista;
        }
    }
}
