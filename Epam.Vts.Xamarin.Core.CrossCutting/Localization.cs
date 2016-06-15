using System;
using System.Collections.Generic;

namespace Epam.Vts.Xamarin.Core.CrossCutting
{
    public enum Lang
    {
        En,
        Ru
    }

    public static class Localization
    {
        public static event Action LangChanged;
        private static Lang _lang;
        private static readonly Dictionary<string, string> Dictionary = new Dictionary<string, string>();

        static Localization()
        {
            Init();
        }

        public static Lang CurrentLang
        {
            
            get { return _lang; }
            set
            {
                if (value != _lang)
                {
                    _lang = value;
                    LangChanged?.Invoke();
                }
            }
        }

        public static string LoginButtonText => GetValue(nameof(LoginButtonText));
        public static string AttentionTitle => GetValue(nameof(AttentionTitle));
        public static string IncorrectLoginData => GetValue(nameof(IncorrectLoginData));
        public static string IncorrectLoginOrPasswordMessage => GetValue(nameof(IncorrectLoginOrPasswordMessage));
        public static string OkText => GetValue(nameof(OkText));
        public static string LoginEntryText => GetValue(nameof(LoginEntryText));
        public static string PasswordEntryText => GetValue(nameof(PasswordEntryText));
        public static string VacationsPageTitle => GetValue(nameof(VacationsPageTitle));
        public static string VacationsFirstHeaderLabel => GetValue(nameof(VacationsFirstHeaderLabel));
        public static string VacationsSecondHeaderLabel => GetValue(nameof(VacationsSecondHeaderLabel));
        public static string UpdateButtonText => GetValue(nameof(UpdateButtonText));

        private static string GetValue(string key)
        {
            var pattern = $"{key}_{CurrentLang}";
            return Dictionary[pattern];
        }

        private static void Init()
        {
            Dictionary.Add("LoginButtonText_En", "Sign in");
            Dictionary.Add("LoginButtonText_Ru", "Войти");
            Dictionary.Add("IncorrectLoginOrPasswordMessage_En", "Incorrect login or password, try again.");
            Dictionary.Add("IncorrectLoginOrPasswordMessage_Ru", "Неправильный логин или пароль, попробуйте заново.");
            Dictionary.Add("AttentionTitle_En", "Attention!");
            Dictionary.Add("AttentionTitle_Ru", "Внимание!");
            Dictionary.Add("OkText_En", "Ok");
            Dictionary.Add("OkText_Ru", "Хорошо");
            Dictionary.Add("LoginEntryText_En", "Email");
            Dictionary.Add("LoginEntryText_Ru", "Эл. почта");
            Dictionary.Add("PasswordEntryText_En", "Password");
            Dictionary.Add("PasswordEntryText_Ru", "Пароль");
            Dictionary.Add("VacationsPageTitle_En", "Vacations List");
            Dictionary.Add("VacationsPageTitle_Ru", "Список отпусков");
            Dictionary.Add("VacationsFirstHeaderLabel_En", "Id");
            Dictionary.Add("VacationsFirstHeaderLabel_Ru", "№");
            Dictionary.Add("VacationsSecondHeaderLabel_En", "Comment");
            Dictionary.Add("VacationsSecondHeaderLabel_Ru", "Комментарий");
            Dictionary.Add("UpdateButtonText_En", "Update");
            Dictionary.Add("UpdateButtonText_Ru", "Обновить");
        }

    }
}
