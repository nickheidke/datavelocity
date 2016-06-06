using dvvWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dvvWeb.Controllers
{
    public class GraphingController : Controller
    {
        //
        // GET: /Graphing/
        public ActionResult Index()
        {
            ConfigModel model;
            model = (ConfigModel)Session["config"];

            return View(model);
        }

        public ActionResult MakeChart()
        {
            return View();
        }
	}
}