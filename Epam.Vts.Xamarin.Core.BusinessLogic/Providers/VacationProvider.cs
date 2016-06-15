using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.Data.DAC.Vacation;

namespace Epam.Vts.Xamarin.Core.BusinessLogic.Providers
{
    public interface IVacationProvider
    {
        Task<IEnumerable<VacationModel>> GetAllAsync();
        Task Update(VacationModel vacation);
        Task<int> Add(VacationModel vacation);
    }

    internal class VacationProvider: IVacationProvider
    {
        private readonly IVacationAccessComponent _vacationComponent;

        public VacationProvider(IVacationAccessComponent vacationComponent)
        {
            _vacationComponent = vacationComponent;
        }

        public async Task<IEnumerable<VacationModel>> GetAllAsync()
        {
            var vacations = await _vacationComponent.GetAllAsync();
            return vacations.Select(v => new VacationModel(v));
        }

        public Task Update(VacationModel vacation)
        {
            return _vacationComponent.Update(vacation);
        }

        public Task<int> Add(VacationModel vacation)
        {
            return _vacationComponent.Add(vacation);
        }
    }
}
