using System;
using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Foundation;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class GalleryViewController : BaseController
    {
        private const string ImageTag = "public.image";

        private UIButton _loadButton;
        private UIButton _cameraButton;
        private UIImageView _displayView;
        private UIImagePickerController _imagePicker;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            Title = Localization.GalleryPageTitle;

            _imagePicker = new UIImagePickerController
            {
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            _imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            _imagePicker.Canceled += Handle_Canceled;

            _displayView = new UIImageView();
            _loadButton = new UIButton { BackgroundColor = UIColor.Gray };
            _loadButton.SetTitle(Localization.GalleryPageTitle, UIControlState.Normal);

            _cameraButton = new UIButton { BackgroundColor = UIColor.DarkGray};
            _cameraButton.SetTitle(Localization.CameraTitle, UIControlState.Normal);

            _loadButton.TouchUpInside += LoadButtonUpSide;
            _cameraButton.TouchUpInside += CameraButtonUpSide;

            View.AddSubviews(_loadButton, _cameraButton, _displayView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                    _loadButton.AtTopOf(View).Plus(100),
                    _loadButton.WithSameLeft(View),
                    _loadButton.Width().EqualTo(150),

                    _cameraButton.AtTopOf(View).Plus(100),
                    _cameraButton.WithSameRight(View),
                    _cameraButton.Width().EqualTo().WidthOf(_loadButton),
                    
                    _displayView.Below(_loadButton, 15),
                    _displayView.Width().EqualTo().WidthOf(View),
                    _displayView.Height().EqualTo().HeightOf(View).Minus(125)
                );
        }

        private void CameraButtonUpSide(object sender, EventArgs e)
        {
            _imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
        }

        private void Handle_Canceled(object sender, EventArgs e)
        {
            _imagePicker.DismissModalViewController(true);
        }

        private void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            var isImage = string.Equals(e.Info[UIImagePickerController.MediaType].ToString(), ImageTag,
                StringComparison.InvariantCultureIgnoreCase);

            if (isImage)
            {
                var originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (originalImage != null)
                {
                    _displayView.Image = originalImage;
                }
            }

            _imagePicker.DismissModalViewController(true);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _loadButton.TouchUpInside -= LoadButtonUpSide;
                _imagePicker.FinishedPickingMedia -= Handle_FinishedPickingMedia;
                _imagePicker.Canceled -= Handle_Canceled;
            }
            base.Dispose(disposing);
        }

        private void LoadButtonUpSide(object sender, EventArgs e)
        {
            _imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            NavigationController.PresentModalViewController(_imagePicker, true);
        }
    }
}