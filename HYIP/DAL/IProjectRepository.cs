using HYIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYIP.DAL
{
    public interface IProjectRepository
      {
        IList<Project> GetProjects();
        void GetName(object arg1, string post);
    }
}//
