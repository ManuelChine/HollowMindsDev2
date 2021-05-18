using HollowMindsDev.BackEnd.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.ViewModel
{
    public interface IMeasurementModelService
    {
        List<MeasurementModel> GetAllModel();
    }
}
