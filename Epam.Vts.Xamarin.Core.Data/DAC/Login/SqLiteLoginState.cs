using System.Linq;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;
using SQLite;

namespace Epam.Vts.Xamarin.Core.Data.DAC.Login
{
    public class SqLiteLoginState: ILoginAccessComponent
    {
        private readonly SQLiteConnection _connection;

        public SqLiteLoginState(ISqLite sqLite)
        {
            _connection = sqLite.GetConnection();
            _connection.CreateTable<PersonCredentialsTransferModel>();

            _connection.Insert(new PersonCredentialsTransferModel {Email = "test", Password = "test"});
        }

        public Task<bool> CheckIsUserRegistered(PersonCredentialsTransferModel context)
        {
            return
                Task.Factory.StartNew(
                    () =>
                        _connection.Table<PersonCredentialsTransferModel>()
                            .FirstOrDefault(x => x.Email == context.Email && x.Password == context.Password) != null);
        }
    }
}
