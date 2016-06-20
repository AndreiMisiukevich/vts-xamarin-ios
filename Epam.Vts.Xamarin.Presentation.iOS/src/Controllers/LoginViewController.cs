using System;
using Cirrious.FluentLayouts.Touch;
using Epam.Vts.Xamarin.Core.BusinessLogic.Models;
using Epam.Vts.Xamarin.Core.BusinessLogic.Providers;
using Epam.Vts.Xamarin.Core.CrossCutting;
using Epam.Vts.Xamarin.Presentation.iOS.Helpers;
using UIKit;

namespace Epam.Vts.Xamarin.Presentation.iOS.Controllers
{
    public class LoginViewController : UIViewController
    {
        private UITextField _emailTextField;
        private UITextField _passwordTextField;
        private UILabel _errorLable;
        private UILabel _emailLable;
        private UILabel _passwordLable;
        private UIButton _loginButton;

        public PersonCredentialsModel UserModel;

        public LoginViewController()
        {
            UserModel = new PersonCredentialsModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            _errorLable = new UILabel
            {
                Text = Localization.IncorrectLoginOrPasswordMessage,
                TextColor = UIColor.Red,
                TextAlignment = UITextAlignment.Center
            };
            _emailLable = new UILabel
            {
                Text = Localization.LoginEntryText,
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Left
            };
            _passwordLable = new UILabel
            {
                Text = Localization.PasswordEntryText,
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Left
            };

            _loginButton = new UIButton { BackgroundColor = UIColor.Gray };
            _loginButton.SetTitle(Localization.LoginButtonText, UIControlState.Normal);

            _emailTextField = new UITextField
            {
                Placeholder = Localization.LoginEntryText,
                BorderStyle = UITextBorderStyle.RoundedRect,
                KeyboardType = UIKeyboardType.EmailAddress,
                Text = "test"
            };

            _passwordTextField = new UITextField
            {
                SecureTextEntry = true,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = Localization.PasswordEntryText,
                Text = "test"
            };

            _emailTextField.EditingDidEndOnExit += HideKeyboard;
            _passwordTextField.EditingDidEndOnExit += HideKeyboard;
            _loginButton.TouchUpInside += Login;

            View.AddSubviews(_errorLable, _emailLable, _emailTextField, _passwordLable, _passwordTextField, _loginButton);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            const int entryWidth = 150;
            const int margin = 10;

            _errorLable.Hidden = true;

            View.AddConstraints(
                _passwordLable.WithSameCenterX(View).Minus(entryWidth / 2),
                _passwordLable.WithSameCenterY(View),

                _passwordTextField.ToRightOf(_passwordLable, margin),
                _passwordTextField.WithSameTop(_passwordLable).Minus(3),
                _passwordTextField.Width().EqualTo(entryWidth),

                _emailLable.Above(_passwordLable, margin),
                _emailLable.WithSameLeft(_passwordLable),

                _emailTextField.ToRightOf(_emailLable),
                _emailTextField.WithSameLeft(_passwordTextField),
                _emailTextField.WithSameTop(_emailLable).Minus(3),
                _emailTextField.Width().EqualTo(entryWidth),

                _loginButton.Below(_passwordLable, margin),
                _loginButton.WithSameCenterX(View),
                _loginButton.Width().EqualTo(entryWidth),

                _errorLable.Above(_emailLable, margin),
                _errorLable.WithSameCenterX(View)
                );
        }

        private async void Login(object sender, EventArgs e)
        {
            var loginProvider = Context.App.Factory.Resolve<ILoginProvider>();
            var context = new PersonCredentialsModel
            {
                Email = _emailTextField.Text,
                Password =_passwordTextField.Text
            };

            if (!await loginProvider.CheckIsUserRegistried(context))
            {
                _errorLable.Hidden = false;
            }
            else
            {
                Context.App.Window.RootViewController = new RootViewController(context);
                _errorLable.Hidden = true;
            }
        }

        private void HideKeyboard(object sender, EventArgs e)
        {
            ((UITextField)sender).ResignFirstResponder();
        }

        protected override void Dispose(bool disposing)
        {
            _emailTextField.EditingDidEndOnExit -= HideKeyboard;
            _passwordTextField.EditingDidEndOnExit -= HideKeyboard;
            _loginButton.TouchUpInside -= Login;
            _emailTextField.Dispose();
            base.Dispose(disposing);
        }
    }
}