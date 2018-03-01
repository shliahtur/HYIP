using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HYIP.Parser
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;


        public HtmlLoader(IParserSettings settings)
        {

            client = new HttpClient();
            url = settings.BaseUrl;
        }

        public async Task<string> GetSourceByPageId()
        {

            var response = await client.GetAsync(url);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}