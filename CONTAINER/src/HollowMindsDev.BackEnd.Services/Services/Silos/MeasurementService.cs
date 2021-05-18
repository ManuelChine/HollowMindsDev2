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
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;

        public MeasurementService(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }
        public void DeleteMeasurement(int id)
        {
            _measurementRepository.Delete(id);
        }

        public IEnumerable<Measurement> GetAllMeasurement()
        {
            return _measurementRepository.GetAll();
        }

        public Measurement GetByIdMeasurement(int id)
        {
            return _measurementRepository.GetById(id);
        }

        public IEnumerable<Measurement> GetLastMeasurement()
        {
            return _measurementRepository.GetLastMeasurement();
        }

        public IEnumerable<Measurement> GetManyMeasurBySilo(int n, int idSilo)
        {
            return _measurementRepository.GetManyMeasurBySilo(n, idSilo);
        }

        public IEnumerable<Measurement> GetMeasurByTime(DateTime time)
        {
            return _measurementRepository.GetMeasurByTime(time); ;
        }

        public void InsertMeasurement(Measurement model)
        {
            _measurementRepository.Insert(model);
        }

        public void UpdateMeasurement(Measurement model)
        {
            _measurementRepository.Update(model);
        }
    }
}
