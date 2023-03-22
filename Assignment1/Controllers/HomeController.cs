using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
   
    public class HomeController : Controller
    {
        bool stat = false;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("SignUp");
        }

        [HttpGet]
        public IActionResult Login()
        {
            stat = false;
            ViewBag.Message = " ";
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            if (stat == false) return RedirectToAction("Login","Home");
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserInformation ui)
        {
            if (UserRepository.CheckEmail(ui) == true && UserRepository.CheckEmail(ui) == true)
            {
                stat = true;
                return View("Dashboard", UserRepository.GetUsers.Where(r=>r.Email == ui.Email));
            }
            else
                stat = false;
            ViewBag.Message = "Please verify Email/Password!";
            return View(ui);
        }

        [HttpPost]
        public IActionResult SignUp(UserInformation ui)
        {
            if (UserRepository.CheckEmail(ui) == true)
            {
                ViewBag.Message ="A user with this email address already exists, do you want to login?";
                return View();
            }
            if (ModelState.IsValid && ui.CPass == ui.Pass && UserRepository.CheckEmail(ui) == false)
            {
                UserRepository.setUsers(ui);
                ui.status = true;
                ViewBag.Message = " ";
                return View("Login",ui);
            }
            else
                ViewBag.Message = " ";
            return View();
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            return View(UserRepository.GetUsers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
