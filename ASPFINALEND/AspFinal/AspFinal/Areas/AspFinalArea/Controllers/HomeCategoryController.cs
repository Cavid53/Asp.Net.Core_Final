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
    public class HomeCategoryController : Controller
    {
        private AppDbContext _context;
        public HomeCategoryController(AppDbContext context)
        {
            this._context = context;
        }
        // GET: HomeCategory
        public IActionResult Index()
        {
            return View(_context.Categories);
        }

      

        // GET: HomeCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.Categories.AddAsync(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: HomeCategory/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Categorie categorie = await _context.Categories.FindAsync(id);
            if (categorie == null) return NotFound();
            return View(categorie);
        }

        // POST: HomeCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Categorie categorie)
        {
            Categorie dbcategorie = await _context.Categories.FindAsync(id);
            if (dbcategorie == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbcategorie.Name = categorie.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: HomeCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Categorie categorie = await _context.Categories.FindAsync(id);
            if (categorie == null) return NotFound();

            return View(categorie);
        }

        // POST: HomeCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Categorie categorie = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}