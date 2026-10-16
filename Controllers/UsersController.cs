using Microsoft.AspNetCore.Mvc;
using api_both.Database;
using api_both.database;
using api_both.Models;

namespace api_both.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Users
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Users/Search
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        // POST: /Users/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string name, string surname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                ViewBag.Message = "Please enter both name and surname.";
                return View();
            }

            get_info get_data = new get_info();
            ViewBag.Message = get_data.get_user_info(name, surname);
            ViewBag.Name = name;
            ViewBag.Surname = surname;
            return View();
        }

        // GET: /Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            store_info store_data = new store_info();
            string message = store_data.store_user_info(user.fullname, user.surname, user.age);

            // Remember in session like your API does
            HttpContext.Session.SetString("Name", user.fullname);
            HttpContext.Session.SetString("Surname", user.surname);
            HttpContext.Session.SetInt32("Age", user.age);

            TempData["Message"] = message;
            return RedirectToAction(nameof(Details), new { id = 1 }); // simple redirect
        }

        // GET: /Users/Details/5
        public IActionResult Details(int id)
        {
            getUserInfoById lookup = new getUserInfoById();
            User user = lookup.get_user_info_by_Id(id);

            if (user == null)
            {
                ViewBag.Message = "User not found with id: " + id;
                return View(new User());
            }

            return View(user);
        }
    }
}