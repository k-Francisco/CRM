using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CRM2.Dependency;
using Xamarin.Forms;
using CRM2.iOS.Services;

[assembly: Dependency(typeof(TokenAuthentication))]
namespace CRM2.iOS.Services
{
    public class TokenAuthentication : ITokenAuthentication
    {
        public List<string> GetTokens()
        {
            List<string> tokens = new List<string>();

            var cookies = NSHttpCookieStorage.SharedStorage.Cookies;
            foreach (var cookie in cookies)
            {
                tokens.Add(cookie.Value);   
            }

            return tokens;
        }
    }
}