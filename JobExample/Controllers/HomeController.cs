using JobExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobContext Db;

        public HomeController():this(new JobContext())
        {

        }

        public HomeController(JobContext db)
        {
            this.Db = db; 
        }

        // GET: Home
        public ActionResult Index()
        {
            // get all jobs 
            // if we want to get cantegory title insted id we need to creat viewmodel type
            var jobs = Db.Jobs.ToList(); 
            return View(jobs);
        }
        [Route("oncategory/{id:int}")]
        [Route("home/oncategory/{id:int}")]
        public ActionResult OnCategory(int id)
        {
            // to improve if id = 0 or null we should redirect to action result index
            var jobs = Db.Jobs.Where(j => j.CategoryId == id).ToList();
            ViewBag.categoryTitle = Db.Categories.SingleOrDefault(c => c.Id == id).CategoryTitle; 
            
            return View(jobs);
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var JobDetail = Db.Jobs.Where(j => j.Id == id).ToList();
            return View(JobDetail);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
