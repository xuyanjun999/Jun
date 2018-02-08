using Jun.Domain.Entity.Sys;
using Jun.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Web.Areas.Sys.Controllers
{
    [Area("Sys")]
    public class MenuController:JunController<MenuEntity>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
