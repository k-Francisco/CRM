using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using CRM2.Droid.Services;
using CRM2.Dependency;
using Android.Webkit;

[assembly: Dependency(typeof(TokenAuthentication))]
namespace CRM2.Droid.Services
{
    public class TokenAuthentication : ITokenAuthentication
    {
        public List<string> GetTokens()
        {
            List<string> tokens = new List<string>();
            string[] token;
            string rtFa = "", FedAuth = "";

            CookieManager cookieManager = CookieManager.Instance;
            cookieManager.SetAcceptCookie(true);
            string generateToken = cookieManager.GetCookie("https://sharepointevo.sharepoint.com/SitePages/home.aspx?AjaxDelta=1");
            if(generateToken != null)
            {
                token = generateToken.Split(new char[] { ';' });
                for(int i = 0; i < token.Length; i++)
                {
                    if (token[i].Contains("rtFa"))
                    {
                        rtFa = token[i].Replace("rtFa=", "");
                        tokens.Add(rtFa);
                    }

                    if (token[i].Contains("FedAuth"))
                    {
                        FedAuth = token[i].Replace("FedAuth=","");
                        tokens.Add(FedAuth);
                    }
                }
            }

            return tokens;
        }
    }
}