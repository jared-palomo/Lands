using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings.Abstractions;
using Plugin.Settings;

namespace Lands.Helpers
{
    public static class Settings
    {
        static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        const string token = "token";
        const string tokenType = "tokenType";
        static readonly string stringDefault = string.Empty;

        public static string Token
        {
            get { return AppSettings.GetValueOrDefault(token, stringDefault); }
            set { AppSettings.AddOrUpdateValue(token, value); }
        }

        public static string TokenType
        {
            get { return AppSettings.GetValueOrDefault(tokenType, stringDefault); }
            set { AppSettings.AddOrUpdateValue(tokenType, value); }
        }
    }
}
