using System.Collections.Generic;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.Data.DAC.Login
{
    public interface ILoginAccessComponent
    {
        Task<bool> CheckIsUserRegistered(PersonCredentialsTransferModel context);
    }

    public class LoginAccessComponent: AbstractAccessComponent<ILoginAccessComponent>, ILoginAccessComponent
    {

        public LoginAccessComponent(IConnectionProvider connectionProvider, ISqLite sqLite, IRestService restService)
            : base(connectionProvider, sqLite, restService)
        {
        }

        protected override void InitConnectionStates()
        {
            InernetConnectionStates = new Dictionary<bool, ILoginAccessComponent>
            {
                {true, new HttpLoginState(RestService)},
                {false, new SqLiteLoginState(SqLite)}
            };
        }

        public Task<bool> CheckIsUserRegistered(PersonCredentialsTransferModel context)
        {
            return CurrentState.CheckIsUserRegistered(context);
        }
    }
}
