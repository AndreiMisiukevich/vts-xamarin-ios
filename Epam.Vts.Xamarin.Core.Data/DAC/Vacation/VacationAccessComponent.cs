using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.Data.DAC.Vacation
{
    public interface IVacationAccessComponent
    {
        Task<IEnumerable<VacationInfoTransferModel>> GetAllAsync();
        Task<VacationInfoTransferModel> GetByIdAsync(int id);
        Task Update(VacationInfoTransferModel transferModel);
        Task<int> Add(VacationInfoTransferModel transferModel);
    }

    public class VacationAccessComponent: AbstractAccessComponent<IVacationAccessComponent>, IVacationAccessComponent
    {
        public VacationAccessComponent(IConnectionProvider connectionProvider, ISqLite sqLite, IRestService restService)
            : base(connectionProvider, sqLite, restService)
        {
        }

        protected override void InitConnectionStates()
        {
            InernetConnectionStates = new Dictionary<bool, IVacationAccessComponent>
            {
                {true, new HttpVacationState(RestService)},
                {false, new SqLiteVacationState(SqLite)}
            };
        }

        public Task<IEnumerable<VacationInfoTransferModel>> GetAllAsync()
        {
            return CurrentState.GetAllAsync();
        }

        public Task<VacationInfoTransferModel> GetByIdAsync(int id)
        {
            return CurrentState.GetByIdAsync(id);
        }

        public Task Update(VacationInfoTransferModel transferModel)
        {
            return CurrentState.Update(transferModel);
        }

        public Task<int> Add(VacationInfoTransferModel transferModel)
        {
            return CurrentState.Add(transferModel);
        }
    }
}
