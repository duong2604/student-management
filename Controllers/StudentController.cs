using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class StudentController : Controller
    {
        // In-memory list — acts like a temporary database
        // (data is lost when the server restarts — that's OK for this lab)
        private static List<Student> listStudents = new List<Student>()
        {
            new Student() { Id = 101, Name = "Hải Nam",    Branch = Branch.IT, Gender = Gender.Male,   IsRegular = true,  Address = "A1-2018", Email = "nam@g.com" },
            new Student() { Id = 102, Name = "Minh Tú",    Branch = Branch.BE, Gender = Gender.Female, IsRegular = true,  Address = "A1-2019", Email = "tu@g.com"  },
            new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male,  IsRegular = false, Address = "A1-2020", Email = "phong@g.com" },
            new Student() { Id = 104, Name = "Xuân Mai",   Branch = Branch.EE, Gender = Gender.Female, IsRegular = false, Address = "A1-2021", Email = "mai@g.com"  },
        };

        // ─────────────────────────────────────────────────────────────
        // GET /Admin/Student/List
        // Route name: "StudentList"
        // ─────────────────────────────────────────────────────────────
        [HttpGet]
        [Route("Admin/Student/List", Name = "StudentList")]
        public IActionResult Index()
        {
            // Pass the full list to the view as its Model
            return View(listStudents);
        }

        // ─────────────────────────────────────────────────────────────
        // GET /Admin/Student/Add  → show the empty create-form
        // ─────────────────────────────────────────────────────────────
        [HttpGet]
        [Route("Admin/Student/Add", Name = "StudentAdd")]
        public IActionResult Create()
        {
            // ViewBag = a bag you can put anything into and read it in the view

            // Load all Gender values so the view can show radio buttons
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            // Load Branch as SelectListItem so the view can show a <select> dropdown
            ViewBag.AllBranches = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT",  Value = "0" },
                new SelectListItem { Text = "BE",  Value = "1" },
                new SelectListItem { Text = "CE",  Value = "2" },
                new SelectListItem { Text = "EE",  Value = "3" },
            };

            return View();
        }

        // ─────────────────────────────────────────────────────────────
        // POST /Admin/Student/Add  → receive form data and save it
        // ─────────────────────────────────────────────────────────────
        [HttpPost]
        [Route("Admin/Student/Add", Name = "StudentAddPost")]
        public IActionResult Create(Student s)
        {
            // Auto-generate next Id (last Id + 1)
            s.Id = listStudents.Last().Id + 1;

            // Add the new student to our list
            listStudents.Add(s);

            // Redirect back to the list view
            return View("Index", listStudents);
        }
    }
}
