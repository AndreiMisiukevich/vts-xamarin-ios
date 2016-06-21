using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.BusinessLogic.Providers;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class SideMenuController : HamburgerAbstractController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.FromRGB(.9f, .9f, .9f);

            var font = UIFont.SystemFontOfSize(17);
            var margin = 5;

            var aboutButton = new UIButton(UIButtonType.System) { Font = font };
            var galleryButton = new UIButton(UIButtonType.System) { Font = font };
            var listOfVacationButton = new UIButton(UIButtonType.System) { Font = font };

            listOfVacationButton.SetTitle(Localization.VacationsPageTitle, UIControlState.Normal);
            aboutButton.SetTitle(Localization.AboutTitleText, UIControlState.Normal);
            galleryButton.SetTitle(Localization.GalleryPageTitle, UIControlState.Normal);

            listOfVacationButton.TouchUpInside += async (sender, e) => 
            {
                SidebarController.CloseMenu();
				var items = await Context.App.Factory.Resolve<IVacationProvider> ().GetAllAsync ();
				NavController.PushViewController(new VacationInfosListViewController(items), false);
            };

            galleryButton.TouchUpInside += (sender, e) =>
            {
                SidebarController.CloseMenu();
                NavController.PushViewController(new GalleryViewController(), false);
            };

            aboutButton.TouchUpInside += (sender, e) =>
            {
                SidebarController.CloseMenu();
                NavController.PushViewController(new AboutController(), false);
            };


            View.AddSubviews(listOfVacationButton, galleryButton, aboutButton);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                listOfVacationButton.WithSameCenterX(View),
                listOfVacationButton.AtTopOf(View).Plus(40),
                listOfVacationButton.Width().EqualTo().WidthOf(View),

                galleryButton.Below(listOfVacationButton, margin),
                galleryButton.WithSameCenterX(View),
                galleryButton.Width().EqualTo().WidthOf(listOfVacationButton),

                aboutButton.Below(galleryButton, margin),
                aboutButton.WithSameCenterX(View),
                aboutButton.Width().EqualTo().WidthOf(galleryButton)
                );
        }
    }
}