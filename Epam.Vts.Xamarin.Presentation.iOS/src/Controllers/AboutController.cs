using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.CrossCutting;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class AboutController : HamburgerAbstractController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            const int width = 150;
            const int height = 100;

            Title = Localization.AboutTitleText;

            var aboutTextView = new UITextView
            {
                Text = Localization.AboutContentText,
                Editable = false,
                TextAlignment = UITextAlignment.Center
            };

            View.AddSubviews(aboutTextView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
               aboutTextView.WithSameCenterX(View),
               aboutTextView.WithSameCenterY(View),
               aboutTextView.Width().EqualTo(width),
               aboutTextView.Height().EqualTo(height)
               );
        }
    }
}