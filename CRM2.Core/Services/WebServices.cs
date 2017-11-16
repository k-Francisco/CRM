using CRM2.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CRM2.Services
{
    public class WebServices
    {
        private HttpClient client;
        private bool isSuccess = false;
        private string baseUrl = "";

        public WebServices()
        {
            client = CreateClient();
        }

        public HttpClient CreateClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            handler.CookieContainer.Add(new Uri("http://sharepointevo.sharepoint.com"), new Cookie("rtFa", Settings.rtFaToken));
            handler.CookieContainer.Add(new Uri("http://sharepointevo.sharepoint.com"), new Cookie("FedAuth", Settings.FedAuthToken));

            HttpClient client = new HttpClient(handler);

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            mediaType.Parameters.Add(item: new NameValueHeaderValue("odata", "verbose"));
            client.DefaultRequestHeaders.Accept.Add(mediaType);

            return client;
        }

        public async Task<string> GetFormDigest()
        {
            string response = "";

            var contents = new StringContent("");
            contents.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");

            try
            {
                var result = await client.PostAsync("https://sharepointevo.sharepoint.com/_api/contextinfo", contents);
                var postresult = result.EnsureSuccessStatusCode();
                if (postresult.IsSuccessStatusCode)
                {
                    response = await postresult.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return response;
        }
    }
}
