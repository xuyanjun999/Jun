using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jun.Web.Models;
using Jun.Data.Repository;
using Microsoft.Extensions.Logging;
using Jun.Domain.Service.Sys;
using Jun.Core.Dependency;
using Jun.Domain.Service.Org;
using Jun.Domain.Entity.Sys;
using Jun.Core.Dto;

namespace Jun.Web.Controllers
{
    public class HomeController : JunController<MenuEntity>
    {

        private readonly IMenuService _menuService;

        private readonly ICompanyService _companyService;

        public HomeController( IMenuService menuService, ICompanyService companyService)
        {
            this._menuService = menuService;
            this._companyService = companyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DashBoard()
        {
            if(_companyService.Repository==_menuService.Repository)
            {
                string a = "";
            }
            return View();
        }

        public IActionResult GetNavigationTree()
        {
            RestResponseDto res = new RestResponseDto();
            var list = _menuService.Repository.GetQueryExp<MenuEntity>(null).ToArray();
            res.Data = list;
            res.Success = true;
            return Json(res);
        }
    }

    class TreeItem
    {
        public int id { get; set; }

        public string Text { get; set; }

        public int? pid { get; set; }


        public string img { get; set; } 
    }
}
