using System.Linq;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.CrossCutting
{
    public interface IVacationRestApiService
    {
        IQueryable<VacationInfoTransferModel> GetAll();
    }
}
