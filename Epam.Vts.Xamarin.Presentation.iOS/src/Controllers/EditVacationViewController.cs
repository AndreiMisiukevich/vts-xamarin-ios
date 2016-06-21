using System;
using System.Runtime.InteropServices;
using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.BusinessLogic.Providers;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class EditVacationViewController : HamburgerAbstractController
    {
        private readonly VacationModel _vacationModel;
        private UIButton _updateButton;

        private UITextField _startDateTextField;
        private UITextField _endDateTextField;
        private UITextField _commentTextField;


        public EditVacationViewController(VacationModel vacationModel)
        {
            _vacationModel = vacationModel;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Title = Localization.VacationsPageTitle;

            var backColor = UIColor.Gray;
            var margin = 20;
            var entryWidth = 150;

            _updateButton = new UIButton { BackgroundColor = UIColor.Gray };
            _updateButton.SetTitle(Localization.UpdateButtonText, UIControlState.Normal);

            _startDateTextField = new UITextField {BackgroundColor = backColor};
            _endDateTextField = new UITextField {BackgroundColor = backColor};
            _commentTextField = new UITextField {BackgroundColor = backColor};

            Update();


            View.AddSubviews(_startDateTextField, _endDateTextField,
                _commentTextField, _updateButton);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _startDateTextField.AtTopOf(View).Plus(100),
                _startDateTextField.WithSameCenterX(View),
                _startDateTextField.Width().EqualTo(entryWidth - 50),

                _endDateTextField.Below(_startDateTextField, margin),
                _endDateTextField.WithSameLeft(_startDateTextField),
                _endDateTextField.Width().EqualTo().WidthOf(_startDateTextField),

                _commentTextField.Below(_endDateTextField, margin),
                _commentTextField.WithSameLeft(_endDateTextField),
                _commentTextField.Width().EqualTo().WidthOf(_endDateTextField),

                _startDateTextField.ToRightOf(_startDateTextField, margin),
                _startDateTextField.WithSameTop(_startDateTextField).Minus(3),
                _startDateTextField.Width().EqualTo(entryWidth - 50),

                _endDateTextField.ToRightOf(_endDateTextField, margin),
                _endDateTextField.WithSameTop(_endDateTextField).Minus(3),
                _endDateTextField.Width().EqualTo().WidthOf(_startDateTextField),

                _commentTextField.ToRightOf(_commentTextField, margin),
                _commentTextField.WithSameTop(_commentTextField).Minus(6),
                _commentTextField.Width().EqualTo().WidthOf(_commentTextField),
                _commentTextField.Height().EqualTo().HeightOf(_commentTextField),
                _commentTextField.WithSameLeft(_endDateTextField),

                _updateButton.Below(_commentTextField, margin),
                _updateButton.WithSameLeft(_commentTextField),
                _updateButton.Width().EqualTo().WidthOf(_endDateTextField)
                );
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _updateButton.TouchDown += UpdateButtonOnTouchDown;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            _updateButton.TouchDown -= UpdateButtonOnTouchDown;
        }

        private async void UpdateButtonOnTouchDown(object sender, EventArgs eventArgs)
        {
            _vacationModel.StartDate = DateTime.Parse(_startDateTextField.Text);
            _vacationModel.EndDate = DateTime.Parse(_endDateTextField.Text);
            _vacationModel.Comment = _commentTextField.Text;

            await Context.App.Factory.Resolve<IVacationProvider>().UpdateAsync(_vacationModel);
        }

        private void Update()
        {
            _startDateTextField.Text = _vacationModel.StartDate.ToString("d");
            _endDateTextField.Text = _vacationModel.EndDate.ToString("d");
            _commentTextField.Text = _vacationModel.Comment;
        }
    }
}