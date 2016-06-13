using dvvWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dvvWeb.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Graphing/
        public ActionResult Index()
        {
            ConfigModel model;
            model = (ConfigModel)Session["config"];

            if (model == null)
            {
                return RedirectToAction("Index", "Config", null);
            }

            return View(model);
        }

        public ActionResult MakeChart()
        {
            return View();
        }
	}
}