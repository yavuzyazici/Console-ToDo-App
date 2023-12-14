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
            PasswordGeneratorModel model = new PasswordGeneratorModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult GeneratePassword(PasswordGeneratorModel model)
        {
            if (ModelState.IsValid)
            {
                model.GeneratedPassword = GenerateRandomPassword(model.PasswordLength, model.SelectedCharacters);
            }
            return View("Index", model);
        }

        private string GenerateRandomPassword(int length, string characters)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(characters, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
