using Jun.Domain.Entity.Org;
using Jun.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Web.Areas.Org.Controllers
{
    [Area("Org")]
    public class CompanyController : JunController<CompanyEntity>
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
