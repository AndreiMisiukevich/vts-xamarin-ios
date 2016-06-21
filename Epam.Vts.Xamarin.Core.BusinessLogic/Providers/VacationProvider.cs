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
        Task UpdateAsync(VacationModel vacation);
        Task<int> AddAsync(VacationModel vacation);
        Task DeleteAsync(VacationModel vacation);
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

        public Task UpdateAsync(VacationModel vacation)
        {
            return _vacationComponent.UpdateAsync(vacation);
        }

        public Task<int> AddAsync(VacationModel vacation)
        {
            return _vacationComponent.AddAsync(vacation);
        }

        public Task DeleteAsync(VacationModel vacation)
        {
            return _vacationComponent.DeleteAsync(vacation);
        }
    }
}
