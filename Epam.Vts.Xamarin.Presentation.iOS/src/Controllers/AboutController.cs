using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.CrossCutting;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class AboutController : BaseController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            const int margin = 40;

            Title = Localization.AboutTitleText;

            var aboutTextView = new UITextView
            {
                Text = Localization.AboutContentText
            };

            View.AddSubviews(aboutTextView);
            
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
               aboutTextView.WithSameCenterX(View),
               aboutTextView.AtTopOf(View).Plus(margin),
               aboutTextView.Width().EqualTo().WidthOf(View).Minus(margin),
               aboutTextView.Height().EqualTo().HeightOf(View));
        }
    }
}