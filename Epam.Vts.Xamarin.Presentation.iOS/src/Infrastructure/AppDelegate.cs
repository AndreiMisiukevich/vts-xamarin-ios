using Epam.Vts.Xamarin.Core.BusinessLogic;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Presentation.iOS.Controllers;
using Foundation;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Infrastructure
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public IContainer Factory;
        public override UIWindow Window { get; set; }
        public RootViewController RootViewController => Window.RootViewController as RootViewController;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {

            InitFactory();

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new LoginViewController(),
                BackgroundColor = UIColor.White,
            };

            Window.MakeKeyAndVisible();
            return true;
        }

        private void InitFactory()
        {
            Factory = new ServiceContainer();
            Factory.Register<ISqLite, SqLite>();
        }
    }
}


