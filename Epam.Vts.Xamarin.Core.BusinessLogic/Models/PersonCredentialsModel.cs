using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.BusinessLogic.Models
{
    public class PersonCredentialsModel : PersonCredentialsTransferModel
    {
        public PersonCredentialsModel(PersonCredentialsTransferModel transferModel)
        {
            Email = transferModel.Email;
            Password = transferModel.Password;
        }
        public PersonCredentialsModel()
        {
        }
    }
}
