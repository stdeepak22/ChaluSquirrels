using ChaluSquirrels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChaluSquirrels.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(ApplicationVariables.Config.Menus);
        }

        [HttpPost]
        public JsonResult SendQuery(Enquery model)
        {
            var result = false;
            List<string> errors = null;
            if(ModelState.IsValid)
            {
                result = true;
            }
            else
            {
                errors = ModelState.Values.SelectMany(c => c.Errors).Select(e=>e.ErrorMessage).ToList();
            }

            return Json(new { result = result, errors = errors });
        }
    }
}