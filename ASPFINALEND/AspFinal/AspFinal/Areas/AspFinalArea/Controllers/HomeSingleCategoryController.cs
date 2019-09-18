using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspFinal.DAL;
using AspFinal.Extentions;
using AspFinal.Models;
using AspFinal.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspFinal.Areas.AspFinalArea.Controllers
{
    [Area("AspFinalArea")]
    public class HomeSingleCategoryController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public HomeSingleCategoryController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: HomeSingleCategory
        public ActionResult Index()
        {
            return View(_context.SingleCategories);
        }

        // GET: HomeSingleCategory/Details/5
        public ActionResult Detail(int? id)
        {
            return View();
        }

        // GET: HomeSingleCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeSingleCategory/Create
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

        // GET: HomeSingleCategory/Edit/5
        public async Task<IActionResult> Update(int? id)
        {

            if (id == null) return NotFound();
            SingleCategorie singleCategorie = await _context.SingleCategories.FindAsync(id);
            if (singleCategorie == null) return NotFound();

            return View(singleCategorie);
          
        }

        // POST: HomeSingleCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SingleCategorie singleCategorie)
        {
            SingleCategorie dbsinglecategory = await _context.SingleCategories.FindAsync(id);
            if (singleCategorie.PhotoUpdate != null)
            {
                if (!singleCategorie.PhotoUpdate.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not photo");
                    return View();
                }
                if (!singleCategorie.PhotoUpdate.CheckImageSize(1))
                {
                    ModelState.AddModelError("Photo", "Image size not more than 1 MB");
                    return View();

                }
                string filename = await singleCategorie.PhotoUpdate.CopyImage(_env.WebRootPath, "banner");
                Utility.DeleteImageFromFolder(_env.WebRootPath, dbsinglecategory.Image);

                dbsinglecategory.Image = filename;
            }
      
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: HomeSingleCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeSingleCategory/Delete/5
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