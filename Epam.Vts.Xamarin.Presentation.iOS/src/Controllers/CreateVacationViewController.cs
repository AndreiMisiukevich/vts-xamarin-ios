//using System;
//using Cirrious.FluentLayouts.Touch;
//using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
//using Epam.Vts.Xamarin.Presentation.iOS.Infrastructure;
//using UIKit;

//namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
//{
//    public class CreateVacationViewController : BaseController
//    {
//        private readonly VacationInfoViewModel _vacationInfoViewModel;

//        public UILabel StartTimeLabel;
//        public UILabel EndTimeLabel;
//        public UILabel StatusLabel;
//        public UILabel TypeLabel;
//        public UILabel CommentLabel;

//        public UIButton StatusButton;
//        public UIButton TypeButton;
//        public UIButton LeftButton;
//        public UIButton RightButton;

//        public UITextField StartDateTextField;
//        public UITextField EndDateTextField;
//        public UITextField CommentTextField;


//        public CreateVacationViewController()
//        {
//            _vacationInfoViewModel = App.Factory.Get<VacationInfoViewModel>();
//        }

//        public override void ViewDidLoad()
//        {
//            base.ViewDidLoad();

//            View.BackgroundColor = UIColor.White;
//            Title = LocalizationConstants.CreateVacationPageTitle.Localize();

//            var backColor = UIColor.Gray;
//            var margin = 20;
//            var entryWidth = 150;

//            StartTimeLabel = new UILabel { Text = LocalizationConstants.StartLable.Localize() };
//            EndTimeLabel = new UILabel { Text = LocalizationConstants.EndLable.Localize() };
//            StatusLabel = new UILabel { Text = LocalizationConstants.StatusLable.Localize() };
//            TypeLabel = new UILabel { Text = LocalizationConstants.TypeLable.Localize() };
//            CommentLabel = new UILabel { Text = LocalizationConstants.CommentLable.Localize() };

//            StatusButton = new UIButton { BackgroundColor = UIColor.Gray };
//            TypeButton = new UIButton { BackgroundColor = UIColor.Gray };
//            LeftButton = new UIButton { BackgroundColor = UIColor.Gray };
//            RightButton = new UIButton { BackgroundColor = UIColor.Gray };

//            LeftButton.SetTitle(LocalizationConstants.CreateLable.Localize(), UIControlState.Normal);
//            RightButton.SetTitle(LocalizationConstants.BackLable.Localize(), UIControlState.Normal);

//            StartDateTextField = new UITextField { BackgroundColor = backColor, };
//            EndDateTextField = new UITextField { BackgroundColor = backColor, };
//            CommentTextField = new UITextField { BackgroundColor = backColor, };

//            Update();

//            StatusButton.TouchUpInside += StatusUpSide;
//            TypeButton.TouchUpInside += TypeButtonUpSide;
//            LeftButton.TouchUpInside += LeftButtonUpSide;
//            RightButton.TouchUpInside += RightButtonUpSide;
//            CommentTextField.EditingDidEndOnExit += ComentValueChanged;
//            StartDateTextField.EditingDidEndOnExit += StartDateValueChanged;
//            EndDateTextField.EditingDidEndOnExit += EndDateValueChanged;

//            View.AddSubviews(StartTimeLabel, EndTimeLabel, StatusLabel,
//                             TypeLabel, CommentLabel, StartDateTextField, EndDateTextField, StatusButton, TypeButton,
//                             CommentTextField, LeftButton, RightButton);

//            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

//            View.AddConstraints(
//                    StartTimeLabel.AtTopOf(View).Plus(100),
//                    StartTimeLabel.WithSameCenterX(View).Minus(50),
//                    StartTimeLabel.Width().EqualTo(entryWidth - 50),

//                    EndTimeLabel.Below(StartTimeLabel, margin),
//                    EndTimeLabel.WithSameLeft(StartTimeLabel),
//                    EndTimeLabel.Width().EqualTo().WidthOf(StartTimeLabel),

//                    StatusLabel.Below(EndTimeLabel, margin),
//                    StatusLabel.WithSameLeft(EndTimeLabel),
//                    StatusLabel.Width().EqualTo().WidthOf(EndTimeLabel),

//                    TypeLabel.Below(StatusLabel, margin),
//                    TypeLabel.WithSameLeft(StatusLabel),
//                    TypeLabel.Width().EqualTo().WidthOf(StatusLabel),

//                    CommentLabel.Below(TypeLabel, margin),
//                    CommentLabel.WithSameLeft(TypeLabel),
//                    CommentLabel.Width().EqualTo().WidthOf(TypeLabel),

//                   StartDateTextField.ToRightOf(StartTimeLabel, margin),
//                   StartDateTextField.WithSameTop(StartTimeLabel).Minus(3),
//                   StartDateTextField.Width().EqualTo(entryWidth - 50),

//                    EndDateTextField.ToRightOf(EndTimeLabel, margin),
//                    EndDateTextField.WithSameTop(EndTimeLabel).Minus(3),
//                    EndDateTextField.Width().EqualTo().WidthOf(StartDateTextField),

//                    StatusButton.ToRightOf(StatusLabel, margin),
//                    StatusButton.WithSameTop(StatusLabel).Minus(6),
//                    StatusButton.Width().EqualTo().WidthOf(EndDateTextField),
//                    StatusButton.WithSameLeft(EndDateTextField),

//                    TypeButton.ToRightOf(TypeLabel, margin),
//                    TypeButton.WithSameTop(TypeLabel).Minus(6),
//                    TypeButton.Width().EqualTo().WidthOf(StatusButton),
//                    TypeButton.WithSameLeft(EndDateTextField),

//                    CommentTextField.ToRightOf(CommentLabel, margin),
//                    CommentTextField.WithSameTop(CommentLabel).Minus(6),
//                    CommentTextField.Width().EqualTo().WidthOf(StatusButton),
//                    CommentTextField.Height().EqualTo().HeightOf(StatusButton),
//                    CommentTextField.WithSameLeft(EndDateTextField),

//                    LeftButton.Below(CommentLabel, margin),
//                    LeftButton.WithSameLeft(CommentLabel),
//                    LeftButton.Width().EqualTo().WidthOf(EndDateTextField),

//                    RightButton.ToRightOf(LeftButton, margin),
//                    RightButton.WithSameTop(LeftButton),
//                    RightButton.Width().EqualTo().WidthOf(EndDateTextField)
//                );
//        }

//        protected override void Dispose(bool disposing)
//        {
//            StatusButton.TouchUpInside += StatusUpSide;
//            TypeButton.TouchUpInside += TypeButtonUpSide;
//            LeftButton.TouchUpInside += LeftButtonUpSide;
//            RightButton.TouchUpInside += RightButtonUpSide;
//            CommentTextField.EditingDidEndOnExit += ComentValueChanged;
//            StartDateTextField.EditingDidEndOnExit += StartDateValueChanged;
//            EndDateTextField.EditingDidEndOnExit += EndDateValueChanged;

//            base.Dispose(disposing);
//        }

//        private void RightButtonUpSide(object sender, EventArgs e)
//        {
//            Context.App.RootViewController.NavController.PopViewController(true);
//        }

//        private void LeftButtonUpSide(object sender, EventArgs e)
//        {
//            _vacationInfoViewModel.Create();
//            Context.App.RootViewController.NavController.PopViewController(true);
//        }

//        private void ComentValueChanged(object sender, EventArgs e)
//        {
//            _vacationInfoViewModel.Comment = ((UITextField)sender).Text;
//            ((UITextField)sender).ResignFirstResponder();
//            Update();
//        }
        
//        private void EndDateValueChanged(object sender, EventArgs e)
//        {
//            _vacationInfoViewModel.EndDate = DateTime.ParseExact(((UITextField)sender).Text, "d", App.Factory.Get<ILocalizer>().GetCurrentCultureInfo());
//            ((UITextField)sender).ResignFirstResponder();
//            Update();
//        }

//        private void StartDateValueChanged(object sender, EventArgs e)
//        {
//            _vacationInfoViewModel.StartDate = DateTime.ParseExact(((UITextField)sender).Text, "d", App.Factory.Get<ILocalizer>().GetCurrentCultureInfo());
//            ((UITextField)sender).ResignFirstResponder();
//            Update();
//        }

//        private void StatusUpSide(object sender, EventArgs e)
//        {
//            var actionSheetAlert = UIAlertController.Create(LocalizationConstants.StatusLable, "", UIAlertControllerStyle.ActionSheet);

//            foreach (var vacationStatusString in EnumHelper.GetVacationStatusStrings())
//            {
//                actionSheetAlert.AddAction(UIAlertAction.Create(vacationStatusString,
//                                           UIAlertActionStyle.Default,
//                                           (action) =>
//                                           {
//                                               _vacationInfoViewModel.Status =
//                                                   vacationStatusString.ToVacationStatus();
//                                               Update();
//                                           }));
//            }

//            actionSheetAlert.AddAction(
//                    UIAlertAction.Create(LocalizationConstants.BackLable.Localize(),
//                    UIAlertActionStyle.Cancel, (action) => { }));

//            var presentationPopover = actionSheetAlert.PopoverPresentationController;
//            if (presentationPopover != null)
//            {
//                presentationPopover.SourceView = this.View;
//                presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
//            }

//            this.PresentViewController(actionSheetAlert, true, null);
//        }

//        private void TypeButtonUpSide(object sender, EventArgs e)
//        {
//            var actionSheetAlert = UIAlertController.Create(LocalizationConstants.StatusLable, "", UIAlertControllerStyle.ActionSheet);

//            foreach (var vacationStatusString in EnumHelper.GetVacationTypeStrings())
//            {
//                actionSheetAlert.AddAction(UIAlertAction.Create(vacationStatusString,
//                                           UIAlertActionStyle.Default,
//                                           (action) =>
//                                           {
//                                               _vacationInfoViewModel.Type =
//                                                   vacationStatusString.ToVacationType();
//                                               Update();
//                                           }));
//            }

//            actionSheetAlert.AddAction(
//                    UIAlertAction.Create(LocalizationConstants.BackLable.Localize(),
//                    UIAlertActionStyle.Cancel, (action) => { }));

//            var presentationPopover = actionSheetAlert.PopoverPresentationController;
//            if (presentationPopover != null)
//            {
//                presentationPopover.SourceView = this.View;
//                presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
//            }

//            this.PresentViewController(actionSheetAlert, true, null);
//        }

//        private void Update()
//        {
//            StatusButton.SetTitle(_vacationInfoViewModel.Status.ToString(), UIControlState.Normal);
//            TypeButton.SetTitle(_vacationInfoViewModel.Type.ToString(), UIControlState.Normal);
//            StartDateTextField.Text = _vacationInfoViewModel.StartDate.ToString("d");
//            EndDateTextField.Text = _vacationInfoViewModel.EndDate.ToString("d");
//            CommentTextField.Text = _vacationInfoViewModel.Comment;
//        }
//    }
//}