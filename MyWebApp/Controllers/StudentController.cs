using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyWebApp.Models;


namespace MyWebApp.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 101,
                    Name = " Lam Hieu",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2021",
                    Email = "hieu@g.com"
                },
                new Student()
                {
                    Id = 101,
                    Name = " Lam Phong",
                    Branch = Branch.BE,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A2-2020",
                    Email = "phong@g.com"
                },
                new Student()
                {
                    Id = 101,
                    Name = " Lam Mai",
                    Branch = Branch.CE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "A3-2022",
                    Email = "mai@g.com"
                },
                new Student()
                {
                    Id = 101,
                    Name = " Lam Dong",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "A4-2023",
                    Email = "dong@g.com"
                }
            };
        }
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1"},
                new SelectListItem { Text = "BE", Value = "1"},
                new SelectListItem { Text = "CE", Value = "1"},
                new SelectListItem { Text = "EE", Value = "1"}
            };
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student s)
        {

            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1"},
                new SelectListItem { Text = "BE", Value = "2"},
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }
    }
}
