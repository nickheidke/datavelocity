using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dvvWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Dynamically view the data movement across your database.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "FAQs";
            ViewBag.Message = "Frequently asked questions";

            return View();
        }
    }
}
