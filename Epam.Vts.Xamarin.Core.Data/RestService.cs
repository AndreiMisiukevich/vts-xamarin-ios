using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;
using Newtonsoft.Json;

namespace Epam.Vts.Xamarin.Core.Data
{

    public interface IRestService
    {
        Task<bool> Login(PersonCredentialsTransferModel transferModel);
        Task<IEnumerable<VacationInfoTransferModel>> GetAllVacations();
        Task UpdateVacation(VacationInfoTransferModel transferModel);
        Task<int> AddVacation(VacationInfoTransferModel transferModel);
    }

    public class RestService: IRestService
    {
        private const string AllVacationsEndPoind = @"http://epbyminw2131:8081/api/vacations";
        private const string VacationEndPoind = @"http://epbyminw2131:8081/api/vacation";
        private const string LoginEndPoint = @"http://epbyminw2131:8081/api/login";

        private readonly HttpClient _client;
        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<bool> Login(PersonCredentialsTransferModel transferModel)
        {
            var response = await Post(LoginEndPoint, transferModel);
            return response.IsSuccessStatusCode &&
                   JsonConvert.DeserializeObject<PersonTransferModel>(await response.Content.ReadAsStringAsync()) != null;

        }

        public async Task<IEnumerable<VacationInfoTransferModel>> GetAllVacations()
        {
            var response = await _client.GetAsync(AllVacationsEndPoind);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var vacations = JsonConvert.DeserializeObject<IEnumerable<VacationInfoTransferModel>>(content);
                return vacations;
            }
            return null;
        }

        public Task UpdateVacation(VacationInfoTransferModel transferModel)
        {
            return Post(VacationEndPoind, transferModel);
        }

        public async Task<int> AddVacation(VacationInfoTransferModel transferModel)
        {
            var response = await Post(VacationEndPoind, transferModel);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Not added!");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        private Task<HttpResponseMessage> Post(string endPoint, object value)
        {
            var parameter = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            return _client.PostAsync(endPoint, parameter);
        }
    }
}
