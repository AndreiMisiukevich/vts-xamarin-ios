using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using Epam.Vts.Xamarin.Presentation.iOS.Infrastructure;
using UIKit;
using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.BusinessLogic.Providers;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class SideMenuController : BaseController
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
            var createVacationButton = new UIButton(UIButtonType.System) { Font = font };

            createVacationButton.SetTitle(Localization.AddVacationPageTitle, UIControlState.Normal);
            listOfVacationButton.SetTitle(Localization.VacationsPageTitle, UIControlState.Normal);
            aboutButton.SetTitle(Localization.AboutTitleText, UIControlState.Normal);
            galleryButton.SetTitle(Localization.GalleryPageTitle, UIControlState.Normal);

            createVacationButton.TouchUpInside += (sender, e) =>
            {
                SidebarController.CloseMenu();
                //NavController.PushViewController(new CreateVacationViewController(), false);
            };

            listOfVacationButton.TouchUpInside += async (sender, e) => 
            {

                SidebarController.CloseMenu();
				var items = await App.AppDelegate.Factory.Resolve<IVacationProvider> ().GetAllAsync ();
				NavController.PushViewController(new VacationInfosListViewController(items), false);
            };

            galleryButton.TouchUpInside += (sender, e) =>
            {
                SidebarController.CloseMenu();
                //NavController.PushViewController(new GalleryViewController(), false);
            };

            aboutButton.TouchUpInside += (sender, e) =>
            {
                SidebarController.CloseMenu();
                NavController.PushViewController(new AboutController(), false);
            };


            View.AddSubviews(createVacationButton, listOfVacationButton, galleryButton, aboutButton);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                createVacationButton.WithSameCenterX(View),
                createVacationButton.AtTopOf(View).Plus(40),
                createVacationButton.Width().EqualTo().WidthOf(View),

                listOfVacationButton.Below(createVacationButton, margin),
                listOfVacationButton.WithSameCenterX(View),
                listOfVacationButton.Width().EqualTo().WidthOf(createVacationButton),

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