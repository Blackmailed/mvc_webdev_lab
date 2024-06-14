using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mvc_webdev_lab1.Models;

namespace mvc_webdev_lab1.Controllers
{
    public class InputController : Controller
    {
        public IActionResult Task1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task1(InputViewModel model)
        {
            int spaceCount = model.InputSentence.Count(c => c == ' ');
            ViewData["SpaceCount"] = spaceCount;
            return View();
        }

        public IActionResult Task2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task2(InputViewModel model)
        {
            string replacedSentence = model.InputSentence.Replace(' ', '_');
            ViewData["ReplacedSentence"] = replacedSentence;
            return View();
        }
    }
}
