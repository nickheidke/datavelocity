using dvvWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dvvWeb.Controllers
{
    public class ConfigController : Controller
    {
        //
        // GET: /Config/
        public ActionResult Index()
        {
            ConfigModel model = new ConfigModel();
            return View(model);
        }
	}
}