using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspFinal.DAL;
using AspFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspFinal.Areas.AspFinalArea.Controllers
{
    [Area("AspFinalArea")]
    public class HomeSingleFeatureController : Controller
    {
        private AppDbContext _context;
        public HomeSingleFeatureController(AppDbContext context)
        {
            this._context = context;
        }
        // GET: HomeSingleFeature
        public IActionResult Index()
        {
            return View(_context.SingleFeatures);
        }

        // GET: HomeSingleFeature/Details/5
        public async Task<IActionResult>  Detail(int? id)
        {
            if (id == null) return NotFound();
            SingleFeature singleFeature =await _context.SingleFeatures.FindAsync(id);
            if (singleFeature == null) return NotFound();
            return View(singleFeature);
        }

        // GET: HomeSingleFeature/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: HomeSingleFeature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SingleFeature singleFeature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

           await _context.SingleFeatures.AddAsync(singleFeature);
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: HomeSingleFeature/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            SingleFeature singleFeature = await _context.SingleFeatures.FindAsync(id);
            if (singleFeature == null) return NotFound();
            return View(singleFeature);
        }

        // POST: HomeSingleFeature/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, SingleFeature singleFeature)
        {
            SingleFeature dbsinglefeature =await _context.SingleFeatures.FindAsync(id);
            if (dbsinglefeature == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbsinglefeature.Title = singleFeature.Title;
            dbsinglefeature.IconField = singleFeature.IconField;
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: HomeSingleFeature/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            SingleFeature singleFeature = await _context.SingleFeatures.FindAsync(id);
            if (singleFeature == null) return NotFound();

            return View(singleFeature);
        }

        // POST: HomeSingleFeature/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            SingleFeature singleFeature =await _context.SingleFeatures.FindAsync(id);
            _context.SingleFeatures.Remove(singleFeature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}