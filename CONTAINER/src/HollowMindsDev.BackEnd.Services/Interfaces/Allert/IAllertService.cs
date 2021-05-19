using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using HollowMindsDev.BackEnd.Infrastructure.Data.Silos;
using HollowMindsDev.BackEnd.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.Services.Interfaces.Allert
{
    public interface IAllertService
    {
        //funzione che va a richiamare measurementRepository e comparare l'ultima misurazione con lo standard
        //restituisce una lista di strighe

        List<AllertModel> CreatorAllert();


    }
}
