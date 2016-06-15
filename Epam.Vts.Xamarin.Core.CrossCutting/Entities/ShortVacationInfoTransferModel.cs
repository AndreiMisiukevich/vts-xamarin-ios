using System;
using Epam.Vts.Xamarin.Core.CrossCutting.Enums;

namespace Epam.Vts.Xamarin.Core.CrossCutting.Entities
{
    public class ShortVacationInfoTransferModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ApproverFullName { get; set; }

        public VacationStatus Status { get; set; }

        public VacationType Type { get; set; }
    }
}
