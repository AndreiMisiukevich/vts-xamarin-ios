using Epam.Vts.Xamarin.Core.CrossCutting.Entities;

namespace Epam.Vts.Xamarin.Core.BusinessLogic.Models
{
    public class PersonModel: PersonTransferModel
    {
        public PersonModel(PersonTransferModel transferModel)
        {
            Id = transferModel.Id;
            FullName = transferModel.FullName;
            VacationDays = transferModel.VacationDays;
            SickDays = transferModel.SickDays;
            Overtime = transferModel.Overtime;
            Credentials = transferModel.Credentials;
        }
    }
}
