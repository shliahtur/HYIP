using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HYIP.DAL;
using HYIP.Models;
using HYIP.Parser;
using PagedList;
using Parser.Core.Habra;

namespace HYIP.Controllers
{
    public class HyipController : Controller
    {

        private IProjectRepository _projectRepository;
        public static List<HyipViewModel> projectList = new List<HyipViewModel>();
        public HyipController()
        {
            _projectRepository = new ProjectRepository(new EFDbContext());
        }
        public HyipController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #region Index

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? page, string sortOrder, string searchString)
        {
           

            HyipViewModel model = new HyipViewModel();
            model.PagedHyipViewModel = CreatePagedHyipViewModel(page, sortOrder, searchString);

            return View(model);
        }

        #endregion Index


        [ChildActionOnly]
        public ActionResult Projects()
        {

            return PartialView();
        }
        
            public IPagedList<HyipViewModel> CreatePagedHyipViewModel(int? page, string sortOrder, string searchString)
        {
            projectList.Clear();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSearchString = searchString;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";


            var projects = _projectRepository.GetProjects();
            foreach(var project in projects)
            {
                projectList.Add(new HyipViewModel() { Project = project,/* Name = project.Name*/ Domain = project.Domain, Hosting = project.Hosting,
                    SSL = project.SSL, Script = project.Script, Design = project.Design, Forums = project.Forums, Monitors = project.Monitors, PicLink = project.PicLink });
            }
            if (searchString != null)
            {
                projectList = projectList.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            switch (sortOrder)
            {
                case "date_desc":
                   projectList = projectList.OrderByDescending(x => x.PostedOn).ToList();
                    break;
                case "Name":
                    projectList = projectList.OrderBy(x => x.Name).ToList();
                    break;
                default:
                    projectList = projectList.OrderBy(x => x.PostedOn).ToList();
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return projectList.ToPagedList(pageNumber, pageSize);
        }
    }
}