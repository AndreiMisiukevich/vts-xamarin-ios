using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.Data.DAC.Login
{
    public class HttpLoginState: ILoginAccessComponent
    {
        private readonly IRestService _restService;

        public HttpLoginState(IRestService restService)
        {
            _restService = restService;
        }

        public Task<bool> CheckIsUserRegistered(PersonCredentialsTransferModel context)
        {
            return _restService.Login(context);
        }
    }
}
