using System;
using System.Linq;
using AngleSharp.Dom.Html;
using System.Collections.Generic;
using AngleSharp.Dom;
using HYIP.Parser;

namespace Parser.Core.Habra
{
    class SiteParser : IParser<string>
    {

        public string Parse(IHtmlDocument document)
        {
            List<string> list = new List<string>();
            var body = document.GetElementsByTagName("table")
                .Where(item => item.ClassName != null && item.ClassName.Contains("hyiplist"))
                .First();

            var names = body.QuerySelectorAll("a").Select(m => m.TextContent);
            foreach (var item in names)
            {
                list.Add(item.ToString());
            }
            string name = list[1] + list[0];

            //var domains = body.QuerySelectorAll("tr")
            //    .Select(m => m.TextContent);
            //foreach (var item in domains)
            //{
            //    list.Add(item.ToString());
            //}

            //string domain = list[4];
            //string hosting = list[5];
            //string SSL = list[6];
            //string script = list[7];
            //string design = list[8];
            //string forum = list[9];
            //string monitors = list[10];

            //var pics = body.QuerySelectorAll("img[src]");
            //foreach (var item in pics)
            //{
            //    var adress = item.Attributes["src"].Value;
            //    list.Add(adress);
            //}
            //string pic = list[11];

            //string all = String.Format(" Name: {0} \n Domain: {1} \n Hosting: {2} \n SSL: {3} \n Script: {4} \n" +
            //                           " Design: {5} \n Forum: {6} \n Monitors: {7} \n Pic Link: {8}", name, domain, hosting, SSL, script, design, forum, monitors, pic);
            return name;
        }
    }
}

