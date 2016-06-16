using System;
using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.BusinessLogic.Providers;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using Epam.Vts.Xamarin.Presentation.iOS.Infrastructure;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class LoginViewController : UIViewController
    {
        public UITextField EmailTextField;
        public UITextField PasswordTextField;
        public UILabel ErrorLable;
        public UILabel EmailLable;
        public UILabel PasswordLable;
        public UIButton LoginButton;

        public PersonCredentialsModel UserModel;

        public LoginViewController()
        {
            UserModel = new PersonCredentialsModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            ErrorLable = new UILabel
            {
                Text = Localization.IncorrectLoginOrPasswordMessage,
                TextColor = UIColor.Red,
                TextAlignment = UITextAlignment.Center,
            };
            EmailLable = new UILabel
            {
                Text = Localization.LoginEntryText,
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Left,
            };
            PasswordLable = new UILabel
            {
                Text = Localization.PasswordEntryText,
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Left,
            };

            LoginButton = new UIButton { BackgroundColor = UIColor.Gray };
            LoginButton.SetTitle(Localization.LoginButtonText, UIControlState.Normal);

            EmailTextField = new UITextField
            {
                Placeholder = Localization.LoginEntryText,
                BorderStyle = UITextBorderStyle.RoundedRect,
                KeyboardType = UIKeyboardType.EmailAddress,
                Text = "dz@epam.com",
            };

            PasswordTextField = new UITextField
            {
                SecureTextEntry = true,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = Localization.PasswordEntryText,
                Text = "test1",
            };

            EmailTextField.EditingDidEndOnExit += HideKeyboard;
            PasswordTextField.EditingDidEndOnExit += HideKeyboard;
            LoginButton.TouchUpInside += Login;

            View.AddSubviews(ErrorLable, EmailLable, EmailTextField, PasswordLable, PasswordTextField, LoginButton);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            const int entryWidth = 150;
            const int margin = 10;

            ErrorLable.Hidden = true;

            View.AddConstraints(
                PasswordLable.WithSameCenterX(View).Minus(entryWidth / 2),
                PasswordLable.WithSameCenterY(View),

                PasswordTextField.ToRightOf(PasswordLable, margin),
                PasswordTextField.WithSameTop(PasswordLable).Minus(3),
                PasswordTextField.Width().EqualTo(entryWidth),

                EmailLable.Above(PasswordLable, margin),
                EmailLable.WithSameLeft(PasswordLable),

                EmailTextField.ToRightOf(EmailLable),
                EmailTextField.WithSameLeft(PasswordTextField),
                EmailTextField.WithSameTop(EmailLable).Minus(3),
                EmailTextField.Width().EqualTo(entryWidth),

                LoginButton.Below(PasswordLable, margin),
                LoginButton.WithSameCenterX(View),
                LoginButton.Width().EqualTo(entryWidth),

                ErrorLable.Above(EmailLable, margin),
                ErrorLable.WithSameCenterX(View)
                );
        }

        private async void Login(object sender, EventArgs e)
        {
            var loginProvider = App.AppDelegate.Factory.Resolve<ILoginProvider>();
            var context = new PersonCredentialsModel
            {
                Email = EmailTextField.Text,
                Password =PasswordTextField.Text
            };

            if (!await loginProvider.CheckIsUserRegistried(context))
            {
                ErrorLable.Hidden = false;
            }
            else
            {
                App.AppDelegate.Window.RootViewController = new RootViewController(context);
                ErrorLable.Hidden = true;
            }
        }

        private void HideKeyboard(object sender, EventArgs e)
        {
            ((UITextField)sender).ResignFirstResponder();
        }

        protected override void Dispose(bool disposing)
        {
            EmailTextField.EditingDidEndOnExit -= HideKeyboard;
            PasswordTextField.EditingDidEndOnExit -= HideKeyboard;
            LoginButton.TouchUpInside -= Login;
            EmailTextField.Dispose();
            base.Dispose(disposing);
        }
    }
}