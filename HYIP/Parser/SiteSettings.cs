using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYIP.Parser
{
    public class SiteSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "http://investorsstartpage.com/";
    }
}