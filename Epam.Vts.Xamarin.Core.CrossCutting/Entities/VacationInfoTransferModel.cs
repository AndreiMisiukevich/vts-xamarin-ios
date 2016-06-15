using System;
using Epam.Vts.Xamarin.Core.CrossCutting.Enums;

namespace Epam.Vts.Xamarin.Core.CrossCutting.Entities
{

    public class VacationInfoTransferModel
    { 
        public int Id { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual int EmployeeId { get; set; }

        public virtual int ApproverId { get; set; }

        public virtual bool NoProjectManagerObjections { get; set; }

        public virtual string Comment { get; set; }

        public virtual bool ConfirmationDocumentAvailable { get; set; }

        public virtual string ProcessInstanceId { get; set; }

        public virtual VacationStatus Status { get; set; }

        public virtual VacationType Type { get; set; }

    }
}
