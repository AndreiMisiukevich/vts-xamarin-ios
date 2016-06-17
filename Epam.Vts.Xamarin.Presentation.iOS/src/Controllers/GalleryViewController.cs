using System;
using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.CrossCutting;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class GalleryViewController : BaseController
    {
        public UIButton LoadButton;
        public UIImageView DisplayView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            this.Title = Localization.GalleryPageTitle;

            LoadButton = new UIButton { BackgroundColor = UIColor.Gray, };
            LoadButton.SetTitle(Localization.GalleryPageTitle, UIControlState.Normal);

            LoadButton.TouchUpInside += LoadButtonUpSide;

            View.AddSubviews(LoadButton);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                    LoadButton.AtTopOf(View).Plus(100),
                    LoadButton.WithSameCenterX(View),
                    LoadButton.Width().EqualTo().WidthOf(LoadButton).Plus(10)
                );
        }


        protected override void Dispose(bool disposing)
        {
            LoadButton.TouchUpInside -= LoadButtonUpSide;

            base.Dispose(disposing);
        }

        private void LoadButtonUpSide(object sender, EventArgs e) { }
    }
}