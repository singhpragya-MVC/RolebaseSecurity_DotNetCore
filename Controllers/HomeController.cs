using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleBasedemo.Data;
using RoleBasedemo.Models;

namespace RoleBasedemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CollegeDbContext collegeDbContext;
        public HomeController(CollegeDbContext applicationDbContext)
        {
            this.collegeDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var colleges = collegeDbContext.College.ToList();
            return View(colleges);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search(string id, string curriculam, double fee)
        {
            var colleges = collegeDbContext.College.Where(x => x.Name.Contains(id)).ToList();
            if (!string.IsNullOrEmpty(curriculam))
            {
                colleges = colleges.Where(x => x.Curriculam.Contains(curriculam)).ToList();
            }
            if (fee != 0)
            {
                colleges = colleges.Where(x => x.Fees.ToString().Contains(fee.ToString())).ToList();
            }
            return View(colleges);
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
