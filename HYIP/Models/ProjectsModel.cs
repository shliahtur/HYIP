using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace HYIP.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Deposit { get; set; }
        public string DepositYesterday { get; set; }
        public string Domain { get; set; }
        public string Hosting { get; set; }
        public string SSL { get; set; }
        public string Script { get; set; }
        public string Design { get; set; }
        public string Forums { get; set; }
        public string Monitors { get; set; }
        public string PicLink { get; set; }
    }
    public class HyipViewModel
    {
        public DateTime PostedOn { get; set; }
        public int TotalProjectscts { get; set; }
        
        public Project Project { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Deposit { get; set; }
        public string DepositYesterday { get; set; }
        public string Domain { get; set; }
        public string Hosting { get; set; }
        public string SSL { get; set; }
        public string Script { get; set; }
        public string Design { get; set; }
        public string Forums { get; set; }
        public string Monitors { get; set; }
        public string PicLink { get; set; }
        public string UrlSlug { get; set; }
        public PagedList.IPagedList<HyipViewModel> PagedHyipViewModel { get; set; }
    }
}