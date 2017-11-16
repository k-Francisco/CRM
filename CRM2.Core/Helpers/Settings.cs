using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM2.Helpers
{
    public class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        private const string rtFaKey = "rtFa_key";
        private static readonly string rtFa = string.Empty;
        public static string rtFaToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(rtFaKey, rtFa);
            }
            set
            {
                AppSettings.AddOrUpdateValue(rtFaKey, value);
            }
        }

        private const string FedAuthKey = "FedAuth_key";
        private static readonly string FedAuth = string.Empty;
        public static string FedAuthToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(FedAuthKey, FedAuth);
            }
            set
            {
                AppSettings.AddOrUpdateValue(FedAuthKey, value);
            }
        }

        private const string formDigestKey = "formdigest_key";
        private static readonly string FormDigest = string.Empty;
        public static string FormDigestValue
        {
            get
            {
                return AppSettings.GetValueOrDefault(formDigestKey, FormDigest);
            }
            set
            {
                AppSettings.AddOrUpdateValue(formDigestKey, value);
            }
        }



        public static void ClearSettings()
        {
            AppSettings.Clear();
        }
    }
}
