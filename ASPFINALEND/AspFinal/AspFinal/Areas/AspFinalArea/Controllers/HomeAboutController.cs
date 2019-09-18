using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspFinal.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspFinal.Areas.AspFinalArea.Controllers
{
    [Area("AspFinalArea")]
    public class HomeAboutController : Controller
    {
        private AppDbContext _context;

        public HomeAboutController(AppDbContext context)
        {
            this._context = context;
        }
        // GET: HomeAbout
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeAbout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeAbout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeAbout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeAbout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeAbout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeAbout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeAbout/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}