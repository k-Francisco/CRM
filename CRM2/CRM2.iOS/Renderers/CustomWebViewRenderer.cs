using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using CRM2.Controls;
using Xamarin.Forms;
using CRM2.iOS.Renderers;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace CRM2.iOS.Renderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            var cookies = NSHttpCookieStorage.SharedStorage.Cookies;
            foreach(var cookie in cookies)
            {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }

            NSUrlCache.SharedCache.RemoveAllCachedResponses();
            NSUrlCache.SharedCache.MemoryCapacity = 0;
            NSUrlCache.SharedCache.DiskCapacity = 0;
        }
    }
}