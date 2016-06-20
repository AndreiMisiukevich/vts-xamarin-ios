using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;
using Ninject.Infrastructure.Language;
using SQLite;

namespace Epam.Vts.Xamarin.Core.Data.DAC.Vacation
{
    internal class SqLiteVacationState : IVacationAccessComponent
    {
        private readonly SQLiteConnection _connection;

        public SqLiteVacationState(ISqLite sqLite)
        {
            _connection = sqLite.GetConnection();
            _connection.CreateTable<VacationInfoTransferModel>();
        }

        public Task<IEnumerable<VacationInfoTransferModel>> GetAllAsync() //TODO: Create TaskCreatorHelper
        {
            return
                Task.Factory.StartNew(() => _connection.Table<VacationInfoTransferModel>().Select(x => x).ToEnumerable());
        }

        public Task<VacationInfoTransferModel> GetByIdAsync(int id)
        {
            return
                Task.Factory.StartNew(
                    () => _connection.Table<VacationInfoTransferModel>().FirstOrDefault(x => x.Id == id));
        }

        public Task Update(VacationInfoTransferModel transferModel)
        {
            return Task.Factory.StartNew(() => _connection.Update(transferModel));
        }

        public Task<int> Add(VacationInfoTransferModel transferModel)
        {
            return Task.Factory.StartNew(() =>
            {
                var table = _connection.Table<VacationInfoTransferModel>();
                transferModel.Id = table.Any() ? table.Max(x => x.Id) + 1 : 1;
                transferModel.ProcessInstanceId = "10" + transferModel.Id;
                _connection.Insert(transferModel);
                return transferModel.Id;
            });
        }
    }
}
