using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using SidebarNavigation;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public abstract class HamburgerAbstractController : UIViewController
    {
        private UIBarButtonItem _barButtonItem;

        protected SidebarController SidebarController => Context.App?.RootViewController.SidebarController;
        protected UINavigationController NavController => Context.App?.RootViewController.NavController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _barButtonItem = new UIBarButtonItem(UIImage.FromBundle("hamb"),
                                                 UIBarButtonItemStyle.Plain,
                                                 (sender, args) => { SidebarController.ToggleMenu(); }
                                                 );

            NavigationItem.SetRightBarButtonItem(_barButtonItem, true);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationItem.SetHidesBackButton(true, false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _barButtonItem.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public abstract class BaseTableController : UITableViewController
    {
        private UIBarButtonItem _barButtonItem;

        protected SidebarController SidebarController => Context.App?.RootViewController.SidebarController;
        protected UINavigationController NavController => Context.App?.RootViewController.NavController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _barButtonItem = new UIBarButtonItem(UIImage.FromBundle("hamb"),
                                                 UIBarButtonItemStyle.Plain,
                                                 (sender, args) => { SidebarController.ToggleMenu(); }
                                                 );

            NavigationItem.SetRightBarButtonItem(_barButtonItem, true);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationItem.SetHidesBackButton(true, false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _barButtonItem.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}