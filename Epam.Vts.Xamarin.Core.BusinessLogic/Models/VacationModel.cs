using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Epam.Vts.Xamarin.Core.CrossCutting.Entities;
using Epam.Vts.Xamarin.Core.CrossCutting.Enums;

namespace Epam.Vts.Xamarin.Core.BusinessLogic.Models
{
    public class VacationModel : VacationInfoTransferModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _employeeId;
        private int _approverId;
        private bool _noProjectManagerObjections;
        private string _comment;
        private bool _confirmationDocumentAvailable;
        private string _processInstanceId;
        private VacationStatus _status;
        private VacationType _type;

        public VacationModel() { }

        public VacationModel(VacationInfoTransferModel transferModel)
        {
            Id = transferModel.Id;
            _startDate = transferModel.StartDate;
            _endDate = transferModel.EndDate;
            _employeeId = transferModel.EmployeeId;
            _approverId = transferModel.ApproverId;
            _noProjectManagerObjections = transferModel.NoProjectManagerObjections;
            _comment = transferModel.Comment;
            _confirmationDocumentAvailable = transferModel.ConfirmationDocumentAvailable;
            _processInstanceId = transferModel.ProcessInstanceId;
            _status = transferModel.Status;
            _type = transferModel.Type;
        }

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
