using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedemo.Data;
using RoleBasedemo.Models;

namespace RoleBasedemo.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CollageController : Controller
    {
        private readonly CollegeDbContext collegeDbContext;
        public CollageController(CollegeDbContext applicationDbContext)
        {
            this.collegeDbContext = applicationDbContext;
        }
        // GET: Collage
        public ActionResult Index()
        {
            var colleges = collegeDbContext.College.ToList();
            return View(colleges);
        }

        // GET: Collage/Details/5
        public ActionResult Details(Guid id)
        {
            var college = collegeDbContext.College.Find(id);
            return View(college);
        }
        [Authorize(Roles = "Admin")]
        // GET: Collage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collage/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(College college)
        {
            try
            {
                // TODO: Add insert logic here
                college.CollegeID = new Guid();
                collegeDbContext.College.Add(college);
                collegeDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Collage/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {

            var college = collegeDbContext.College.Find(id);
            return View(college);
        }

        // POST: Collage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(College college)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    collegeDbContext.College.Update(college);
                    collegeDbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Collage/Delete/5
        public ActionResult Delete(Guid id)
        {
            var college = collegeDbContext.College.Find(id);
            return View(college);
        }

        // POST: Collage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(College college)
        {
            try
            {
                // TODO: Add delete logic here

                collegeDbContext.College.Remove(college);
                collegeDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}