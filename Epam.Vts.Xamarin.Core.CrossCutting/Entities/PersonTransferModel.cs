
namespace Epam.Vts.Xamarin.Core.CrossCutting.Entities
{
    public class PersonTransferModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public float VacationDays { get; set; }

        public float SickDays { get; set; }

        public float Overtime { get; set; }

        public PersonCredentialsTransferModel Credentials { get; set; }
    }
}