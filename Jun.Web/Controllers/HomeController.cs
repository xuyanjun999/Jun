using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jun.Web.Models;

namespace Jun.Web.Controllers
{
    public class HomeController : Controller
    {
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
            return View();
        }

        public IActionResult GetNavigationTree()
        {
            List<TreeItem> list = new List<TreeItem>();
            list.Add(new TreeItem()
            {
                id = 1,
                Text = "合同管理"
            });
            list.Add(new TreeItem()
            {
                id = 2,
                pid = 1,
                Text = "合同登记"
            });
            list.Add(new TreeItem()
            {
                id = 3,
                pid = 1,
                Text = "合同报价"
            });
            list.Add(new TreeItem()
            {
                id = 4,
                pid = 3,
                Text = "电梯商务报价"
            });
            return Json(list);
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
