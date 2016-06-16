using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using UIKit;
using SidebarController = SidebarNavigation.SidebarController;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class BaseController : UIViewController
    {
        private UIBarButtonItem _barButtonItem;

        protected SidebarController SidebarController => App.AppDelegate?.RootViewController.SidebarController;
        protected NavController NavController => App.AppDelegate?.RootViewController.NavController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _barButtonItem = new UIBarButtonItem(UIImage.FromBundle("threelines"),
                                                 UIBarButtonItemStyle.Plain,
                                                 (sender, args) => { SidebarController.ToggleMenu(); }
                                                 );

            NavigationItem.SetLeftBarButtonItem(_barButtonItem, true);
        }

        protected override void Dispose(bool disposing)
        {
            _barButtonItem.Dispose();

            base.Dispose(disposing);
        }
    }

    public class BaseTableController : UITableViewController
    {
        private UIBarButtonItem _barButtonItem;

        protected SidebarController SidebarController => App.AppDelegate?.RootViewController.SidebarController;
        protected NavController NavController => App.AppDelegate?.RootViewController.NavController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _barButtonItem = new UIBarButtonItem(UIImage.FromBundle("threelines"),
                                                 UIBarButtonItemStyle.Plain,
                                                 (sender, args) => { SidebarController.ToggleMenu(); }
                                                 );

            NavigationItem.SetLeftBarButtonItem(_barButtonItem, true);
        }

        protected override void Dispose(bool disposing)
        {
            _barButtonItem.Dispose();

            base.Dispose(disposing);
        }
    }
}