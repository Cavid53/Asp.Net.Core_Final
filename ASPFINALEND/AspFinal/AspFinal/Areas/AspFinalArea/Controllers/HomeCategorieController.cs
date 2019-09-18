using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspFinal.Areas.AspFinalArea.Controllers
{
    [Area("AspFinalArea")]
    public class HomeCategorieController : Controller
    {
        // GET: HomeCategorie
        public IActionResult Index()
        {
            return View();
        }

        // GET: HomeCategorie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeCategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeCategorie/Create
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

        // GET: HomeCategorie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeCategorie/Edit/5
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

        // GET: HomeCategorie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeCategorie/Delete/5
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