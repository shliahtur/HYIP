using HYIP.Models;
using HYIP.Parser;
using Parser.Core.Habra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HYIP.DAL
{
    public class ProjectRepository : IProjectRepository
    {
        private EFDbContext _context;

        public ProjectRepository(EFDbContext context)
        {
            _context = context;
        }
         public IList<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }
        string GetName(object arg1, string post)
        {
            ParserWorker<string> parser;

                parser = new ParserWorker<string>(new SiteParser());
                parser.OnNewData += Parser_OnNewData;
            }

            private void Parser_OnNewData(object arg1, string post)
            {

                label1.Text = post;

            }
            public void FormMain_Load(object sender, EventArgs e)
            {
                parser.Settings = new SiteSettings();
                parser.Start();
            }
       
        }
    }
}