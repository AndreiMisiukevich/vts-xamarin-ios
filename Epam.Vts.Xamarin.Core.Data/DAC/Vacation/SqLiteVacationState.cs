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
        private readonly SQLiteConnection _sqLiteConnection;

        public SqLiteVacationState(ISqLite sqLite)
        {
            _sqLiteConnection = sqLite.GetConnection();
            _sqLiteConnection.CreateTable<VacationInfoTransferModel>();

            _sqLiteConnection.InsertAll(
                Enumerable.Range(1, 20)
                    .Select((x, i) => new VacationInfoTransferModel {Id = i, Comment = $"Comment_{i}"}));
        }

        public Task<IEnumerable<VacationInfoTransferModel>> GetAllAsync() //TODO: Create TaskCreatorHelper
        {
            return
                Task.Factory.StartNew(() => _sqLiteConnection.Table<VacationInfoTransferModel>().Select(x => x).ToEnumerable());
        }

        public Task<VacationInfoTransferModel> GetByIdAsync(int id)
        {
            return
                Task.Factory.StartNew(
                    () => _sqLiteConnection.Table<VacationInfoTransferModel>().FirstOrDefault(x => x.Id == id));
        }

        public Task Update(VacationInfoTransferModel transferModel)
        {
            return Task.Factory.StartNew(() => _sqLiteConnection.Update(transferModel));
        }

        public Task<int> Add(VacationInfoTransferModel transferModel)
        {
            return Task.Factory.StartNew(() =>
            {
                var table = _sqLiteConnection.Table<VacationInfoTransferModel>();
                transferModel.Id = table.Any() ? table.Max(x => x.Id) + 1 : 1;
                transferModel.ProcessInstanceId = "10" + transferModel.Id;
                _sqLiteConnection.Insert(transferModel);
                return transferModel.Id;
            });
        }
    }
}
