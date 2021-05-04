using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using HollowMindsDev.BackEnd.Services.Interfaces.Allert;
using HollowMindsDev.BackEnd.Services.Services.Silos;
using HollowMindsDev.BackEnd.Services.Services.ViewModel;
using HollowMindsDev.BackEnd.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HollowMindsDev.BackEnd.Services.Services.Allert
{
    public class AllertService : IAllertService
    {
        //bisogna modificare e usare il modello confezionato
        //creare le lista di bool
        //e aggiustare dove serve

        private readonly MeasurementModelService _measurementModelService;
        private readonly decimal _warning;
        private readonly decimal _allarm;

        public AllertService(MeasurementModelService measurementModelService)
        {
            _measurementModelService = measurementModelService;
            _warning = 5;
            _allarm = 10;
        }


        public List<AllertModel> CreatorAllert()
        {
            List<AllertModel> AllertOutput = new List<AllertModel>();
            List<MeasurementModel> AllertParameters = _measurementModelService.GetAllModel();
            List<bool> Sensor = new List<bool>();


            for (int i = 0; i < AllertParameters.Count; i++)
            {
                Sensor.Add(AllertParameters[i].Measurement.Sensor0);
                Sensor.Add(AllertParameters[i].Measurement.Sensor1);
                Sensor.Add(AllertParameters[i].Measurement.Sensor2);
                Sensor.Add(AllertParameters[i].Measurement.Sensor3);
                Sensor.Add(AllertParameters[i].Measurement.Sensor4);
                Sensor.Add(AllertParameters[i].Measurement.Sensor5);
                Sensor.Add(AllertParameters[i].Measurement.Sensor6);
                Sensor.Add(AllertParameters[i].Measurement.Sensor7);

                //temperatureTop
                if (AllertParameters[i].Measurement.TemperatureTop > (AllertParameters[i].Limit.Temperature * _warning / 100) + AllertParameters[i].Limit.Temperature)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum temperature limit at the top by +{_warning}%" });
                }
                else if (AllertParameters[i].Measurement.TemperatureTop < AllertParameters[i].Limit.Temperature * (100 - _warning) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum temperature limit at the top by +{_warning}%" });
                }

                if (AllertParameters[i].Measurement.TemperatureTop > (AllertParameters[i].Limit.Temperature * _allarm / 100) + AllertParameters[i].Limit.Temperature)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum temperature limit at the top by -{_allarm}%" });
                }
                else if (AllertParameters[i].Measurement.TemperatureTop < AllertParameters[i].Limit.Temperature * (100 - _allarm) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum temperature limit at the top by -{_allarm}%" });
                }

                //temperatureBottom
                if (AllertParameters[i].Measurement.TemperatureBottom > (AllertParameters[i].Limit.Temperature * _warning / 100) + AllertParameters[i].Limit.Temperature)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum temperature limit at the bottom by +{_warning}%" });
                }
                else if (AllertParameters[i].Measurement.TemperatureBottom < AllertParameters[i].Limit.Temperature * (100 - _warning) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum temperature limit at the bottom by +{_warning}%" });
                }

                if (AllertParameters[i].Measurement.TemperatureBottom > (AllertParameters[i].Limit.Temperature * _allarm / 100) + AllertParameters[i].Limit.Temperature)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum temperature limit at the bottom by -{_allarm}%" });
                }
                else if (AllertParameters[i].Measurement.TemperatureBottom < AllertParameters[i].Limit.Temperature * (100 - _allarm) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum temperature limit at the bottom by -{_allarm}%" });
                }







                //Pressure
                if (AllertParameters[i].Measurement.Pressure > (AllertParameters[i].Limit.Preassure * _warning / 100) + AllertParameters[i].Limit.Preassure)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum preassure limit by +{_warning}%" });
                }
                else if (AllertParameters[i].Measurement.Pressure < AllertParameters[i].Limit.Preassure * (100 - _warning) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum preassure limit by +{_warning}%" });
                }

                if (AllertParameters[i].Measurement.Pressure > (AllertParameters[i].Limit.Preassure * _allarm / 100) + AllertParameters[i].Limit.Preassure)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum preassure limit by -{_allarm}%" });
                }
                else if (AllertParameters[i].Measurement.Pressure < AllertParameters[i].Limit.Preassure * (100 - _allarm) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum preassure limit by -{_allarm}%" });
                }









                //umidityTop
                if (AllertParameters[i].Measurement.UmidityTop > (AllertParameters[i].Limit.Umidity * _warning / 100) + AllertParameters[i].Limit.Umidity)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum umidity limit at the top by +{_warning}%" });
                }
                else if (AllertParameters[i].Measurement.UmidityTop < AllertParameters[i].Limit.Umidity * (100 - _warning) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum umidity limit at the top by +{_warning}%" });
                }

                if (AllertParameters[i].Measurement.UmidityTop > (AllertParameters[i].Limit.Umidity * _allarm / 100) + AllertParameters[i].Limit.Umidity)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum umidity limit at the top by -{_allarm}%" });
                }
                else if (AllertParameters[i].Measurement.UmidityTop < AllertParameters[i].Limit.Umidity * (100 - _allarm) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum umidity limit at the top by -{_allarm}%" });
                }

                //umidityBottom
                if (AllertParameters[i].Measurement.UmidityBottom > (AllertParameters[i].Limit.Umidity * _warning / 100) + AllertParameters[i].Limit.Umidity)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum umidity limit at the bottom by +{_warning}%" });
                }
                else if (AllertParameters[i].Measurement.UmidityBottom < AllertParameters[i].Limit.Umidity * (100 - _warning) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum umidity limit at the bottom by +{_warning}%" });
                }

                if (AllertParameters[i].Measurement.UmidityBottom > (AllertParameters[i].Limit.Umidity * _allarm / 100) + AllertParameters[i].Limit.Umidity)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum umidity limit at the bottom by -{_allarm}%" });
                }
                else if (AllertParameters[i].Measurement.UmidityBottom < AllertParameters[i].Limit.Umidity * (100 - _allarm) / 100)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum umidity limit at the bottom by -{_allarm}%" });
                }


                //level
                int count = 0;
                bool broken = false;
                if (Sensor[0])
                {
                    count++;
                }
                for (int y = 1; y < Sensor.Count; y++)
                {
                    if (Sensor[y])
                    {
                        if (!Sensor[y-1])
                        {
                            broken = true;
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }

                if (broken)
                {
                    AllertOutput.Add(new AllertModel { Type = "ALLARM", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} some sensors are broken" });
                }
                else
                {
                    if (count >= AllertParameters[i].Limit.LevelMax)
                    {
                        AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the maximum level limit by {(count + 1) - AllertParameters[i].Limit.LevelMax} levels" });
                    }
                    if (count < AllertParameters[i].Limit.LevelMin)
                    {
                        AllertOutput.Add(new AllertModel { Type = "WARNING", Body = $": silo n° {AllertParameters[i].Measurement.IdSilo} exceeded the minimum level limit by {AllertParameters[i].Limit.LevelMin - count} levels" });
                    }
                }
                

                
            }

            return AllertOutput;
        }
    }
}


