using Epam.Vts.Xamarin.Presentation.iOS.Infrastructure;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Helpers
{
    public static class Context
    {
        public static AppDelegate App = UIApplication.SharedApplication.Delegate as AppDelegate;
    }
}