using Microsoft.AspNetCore.Mvc;
using Password.Models;
using System.Diagnostics;
using System;
using System.Linq;

namespace Password.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            var model = new PasswordModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult Index(PasswordModel model)
        {

            model.Generate();
            return View(model);

        }

    }
}
