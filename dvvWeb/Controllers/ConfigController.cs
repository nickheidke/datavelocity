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
			ConfigModel model;
			model = (ConfigModel)Session["config"];

			if (model == null)
			{
				model = new ConfigModel();

				//Let's set some defaults so we don't get ugly 0's on the form
				model.Preferences.NumberOfPoints = 200;
				model.Preferences.PollingFrequency = 10;
			}
		   
			return View(model);
		}

		[HttpPost]
		public ActionResult Index(string action, ConfigModel model)
		{
			Session.Add("config", model);

			return RedirectToAction("Index", "Dashboard");
		}
	}
}