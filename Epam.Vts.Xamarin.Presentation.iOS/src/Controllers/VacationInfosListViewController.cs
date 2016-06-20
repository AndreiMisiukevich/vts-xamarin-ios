using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Foundation;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class VacationInfosListViewController : BaseTableController
    {
        private readonly List<VacationModel> _itemsSource;
        public const string ReuseId = "ReuseId";

		public VacationInfosListViewController(IEnumerable<VacationModel> items)
		{
			_itemsSource = items.ToList ();
		}

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _itemsSource[indexPath.Row];

            //Context.App.RootViewController.NavController.PushViewController(new EditVacationViewController(item),
            //    true);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Title = Localization.VacationsPageTitle;
            TableView.RegisterClassForCellReuse(typeof(VacationInfoCell), ReuseId);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            TableView.ContentInset = new UIEdgeInsets(TopLayoutGuide.Length, 0, 0, 0);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (VacationInfoCell) tableView.DequeueReusableCell(ReuseId);
            cell.UpdateData(_itemsSource[indexPath.Row]);
            return cell;
        }

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _itemsSource.Count;
		}
    }

    public class VacationInfoCell : UITableViewCell
    {
        private readonly UILabel _startDate;
        private readonly UILabel _endDate;
        private readonly UILabel _approverFullName;
        private readonly UILabel _status;
        private readonly UILabel _type;

        public void UpdateData(VacationModel vacationModel)
        {
            _startDate.Text = vacationModel.StartDate.ToString("dd/MM/yyyy");
            _endDate.Text = vacationModel.EndDate.ToString("dd/MM/yyyy");
            _approverFullName.Text = vacationModel.ApproverId.ToString();
            _status.Text = vacationModel.Status.ToString();
            _type.Text = vacationModel.Type.ToString();
        }

        public VacationInfoCell(IntPtr ptr) : base(ptr)
        {
            var cellFont = UIFont.SystemFontOfSize(11);
            var cellTextColor = UIColor.Blue;

            _startDate = new UILabel {Font = cellFont, TextColor = cellTextColor};
            _endDate = new UILabel {Font = cellFont, TextColor = cellTextColor, TextAlignment = UITextAlignment.Left};
            _approverFullName = new UILabel
            {
                Font = cellFont,
                TextColor = cellTextColor,
                TextAlignment = UITextAlignment.Left
            };
            _status = new UILabel {Font = cellFont, TextColor = cellTextColor, TextAlignment = UITextAlignment.Left};
            _type = new UILabel {Font = cellFont, TextColor = cellTextColor, TextAlignment = UITextAlignment.Left};

            ContentView.Add(_startDate);
            ContentView.Add(_endDate);
            ContentView.Add(_approverFullName);
            ContentView.Add(_status);
            ContentView.Add(_type);

            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            ContentView.AddConstraints(
                _startDate.WithSameTop(ContentView),
                _startDate.WithSameLeft(ContentView),
                _startDate.WithSameHeight(ContentView),

                _endDate.ToRightOf(_startDate, 6),
                _endDate.WithSameTop(_startDate),
                _endDate.WithSameWidth(_startDate),
                _endDate.WithSameHeight(_startDate),

                _approverFullName.ToRightOf(_endDate, 6),
                _approverFullName.WithSameTop(_startDate),
                _approverFullName.WithSameHeight(_startDate),

                _status.ToRightOf(_approverFullName, 6),
                _status.WithSameTop(_startDate),
                _status.WithSameHeight(_startDate),

                _type.ToRightOf(_status, 6),
                _type.WithSameTop(_startDate),
                _type.WithSameHeight(_startDate)
                );
        }
    }
}
