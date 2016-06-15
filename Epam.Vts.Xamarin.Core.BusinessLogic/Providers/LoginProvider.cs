using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.Data.DAC.Login;

namespace Epam.Vts.Xamarin.Core.BusinessLogic.Providers
{
    public interface ILoginProvider
    {
        Task<bool> CheckIsUserRegistried(PersonCredentialsModel context);
    }

    internal class LoginProvider: ILoginProvider
    {
        private readonly ILoginAccessComponent _loginComponent;

        public LoginProvider(ILoginAccessComponent loginComponent)
        {
            _loginComponent = loginComponent;
        }

        public Task<bool> CheckIsUserRegistried(PersonCredentialsModel context)
        {
            return _loginComponent.CheckIsUserRegistered(context);
        }
    }
}
