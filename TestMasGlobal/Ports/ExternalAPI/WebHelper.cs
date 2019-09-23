using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestMasGlobal.Ports.ExternalAPI
{
    public class WebHelper
    {
        private readonly HttpClient ClienteWeb;

        public WebHelper()
        {
            ClienteWeb = new HttpClient();
        }

        public async Task<string> Getter(string url)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var response = await ClienteWeb.GetAsync(url).ConfigureAwait(false);
            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }

    }
}