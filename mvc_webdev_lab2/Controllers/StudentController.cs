using Microsoft.AspNetCore.Mvc;
using mvc_webdev_lab2.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc_webdev_lab2.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        private static string currentGroup = string.Empty;

        public IActionResult Index(string group = "")
        {
            ViewData["Author"] = "Судаков Даниил Владимирович";
            ViewData["Group"] = "571-2";

            if (!string.IsNullOrEmpty(group))
            {
                currentGroup = group;
            }

            var groupStudents = students.Where(s => s.Group == currentGroup).ToList();
            return View(groupStudents);
        }

        public IActionResult Create()
        {
            ViewData["Author"] = "Судаков Даниил Владимирович";
            ViewData["Group"] = "571-2";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            ViewData["Author"] = "Судаков Даниил Владимирович";
            ViewData["Group"] = "571-2";

            if (ModelState.IsValid)
            {
                if (student.FirstName == "Евгений" && student.LastName == "Мурзин" && student.MiddleName == "Сергеевич")
                {
                    return RedirectToAction("ShowAllGroups");
                }

                if (students.Any(s => s.FirstName == student.FirstName && s.LastName == student.LastName && s.MiddleName == student.MiddleName && s.Group == student.Group))
                {
                    ModelState.AddModelError("", "Ученик с такими данными уже существует в этой группе.");
                }
                else
                {
                    students.Add(student);
                    currentGroup = student.Group;
                    return RedirectToAction("Index", new { group = student.Group });
                }
            }
            return View(student);
        }

        public IActionResult ShowAllGroups()
        {
            ViewData["Author"] = "Судаков Даниил Владимирович";
            ViewData["Group"] = "571-2";

            var groupedStudents = students.GroupBy(s => s.Group).ToList();
            return View(groupedStudents);
        }
    }

}
