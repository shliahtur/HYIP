using HYIP.Parser;
using Parser.Core.Habra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYIP.DAL
{
    public class ParserRepository
    {
        ParserWorker<string> parser;

        public ParserRepository()
        {
            parser = new ParserWorker<string>(new SiteParser());
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string post)
        {
          string message = post;

        }


        private void Parser_Load(object sender, EventArgs e)
        {
            parser.Settings = new SiteSettings();
            parser.Start();
        }
    }
}