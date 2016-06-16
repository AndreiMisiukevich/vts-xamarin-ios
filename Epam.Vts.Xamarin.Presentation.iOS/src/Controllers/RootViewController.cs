using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.BusinessLogic.Providers;
using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using Epam.Vts.Xamarin.Presentation.iOS.Infrastructure;
using SidebarNavigation;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class RootViewController : UIViewController
    {
        public PersonCredentialsModel UserModel { get; private set; }
        public SidebarController SidebarController { get; private set; }
        public NavController NavController { get; private set; }

        public RootViewController(PersonCredentialsModel userModel)
        {
            UserModel = userModel;
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            var vacationInfoList = await App.AppDelegate.Factory.Resolve<IVacationProvider>().GetAllAsync();

            NavController = new NavController();
            NavController.PushViewController(new VacationInfosListViewController(), false);

            SidebarController = new SidebarController(this, NavController, new SideMenuController())
            {
                MenuWidth = 220,
                ReopenOnRotate = false,
                MenuLocation = MenuLocations.Left
            };
        }
    }
}