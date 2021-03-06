﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

        public static string LoginButtonText => GetValue();
        public static string AttentionTitle => GetValue();
        public static string IncorrectLoginData => GetValue();
        public static string IncorrectLoginOrPasswordMessage => GetValue();
        public static string OkText => GetValue();
        public static string LoginEntryText => GetValue();
        public static string PasswordEntryText => GetValue();
        public static string VacationsPageTitle => GetValue();
        public static string VacationsFirstHeaderLabel => GetValue();
        public static string VacationsSecondHeaderLabel => GetValue();
        public static string UpdateButtonText => GetValue();
        public static string AboutTitleText => GetValue();
        public static string AboutContentText => GetValue();
        public static string GalleryPageTitle => GetValue();
        public static string CameraTitle => GetValue();
        public static string CancelText => GetValue();
        public static string YesText => GetValue();
        public static string DeleteSureMessage => GetValue();
        public static string DeleteSureTitle => GetValue();
        public static string AddVacationPageTitle => GetValue();

        private static string GetValue([CallerMemberName]string key = null)
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
            Dictionary.Add("AboutTitleText_En", "About");
            Dictionary.Add("AboutTitleText_Ru", "О программе");
            Dictionary.Add("AboutContentText_En", "(с) EPAM, 2016");
            Dictionary.Add("AboutContentText_Ru", "(с) ЕПАМ, 2016");
            Dictionary.Add("GalleryPageTitle_En", "Gallery");
            Dictionary.Add("GalleryPageTitle_Ru", "Галерея");
            Dictionary.Add("CameraTitle_En", "Camera");
            Dictionary.Add("CameraTitle_Ru", "Камера");
            Dictionary.Add("AddVacationPageTitle_En", "New vacation");
            Dictionary.Add("AddVacationPageTitle_Ru", "Новая запись");

            Dictionary.Add("СancelText_En", "Cancel");
            Dictionary.Add("СancelText_Ru", "Отмена");

            Dictionary.Add("DeleteSureTitle_En", "Delete item");
            Dictionary.Add("DeleteSureTitle_Ru", "Удалить запись");

            Dictionary.Add("DeleteSureMessage_En", "Are you sure?");
            Dictionary.Add("DeleteSureMessage_Ru", "Вы уверены?");

            Dictionary.Add("YesText_En", "Yes");
            Dictionary.Add("YesText_Ru", "Да");
        }

    }
}
