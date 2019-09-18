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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace AspFinal.Areas.AspFinalArea.Controllers
{
    [Area("AspFinalArea")]
    public class HomeProductAreaController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;

        public HomeProductAreaController(AppDbContext context,IHostingEnvironment environment)
        {
            _context = context;
            _env = environment;
        }

        // GET: HomeProductArea
        public IActionResult Index()
        {
            return View(_context.Products);
        }

        // GET: HomeProductArea/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: HomeProductArea/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeProductArea/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid ||
                  ModelState["RegularPrice"].ValidationState == ModelValidationState.Invalid ||
                  ModelState["Photo"].ValidationState == ModelValidationState.Invalid 
                  )
            {
                return View();
            }

            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not photo");
                return View();
            }

            if (!product.Photo.CheckImageSize(1))
            {
                ModelState.AddModelError("Photo", "Image size not more than 1 MB");
                return View();
            }

            string filename = await product.Photo.CopyImage(_env.WebRootPath, "product");

            product.Image = filename;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: HomeProductArea/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: HomeProductArea/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product)
        {
            Product dbproduct = await _context.Products.FindAsync(id);
            if (dbproduct == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Detail"].ValidationState == ModelValidationState.Invalid)
            {
                return View(dbproduct);
            }

            if (product.PhotoUpdate != null)
            {
                if (!product.PhotoUpdate.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not photo");
                    return View();
                }
                if (!product.PhotoUpdate.CheckImageSize(1))
                {
                    ModelState.AddModelError("Photo", "Image size not more than 1 MB");
                    return View();

                }
                string filename = await product.PhotoUpdate.CopyImage(_env.WebRootPath, "slider");
                Utility.DeleteImageFromFolder(_env.WebRootPath, dbproduct.Image);

                dbproduct.Image = filename;
            }
            dbproduct.Name = product.Name;
            dbproduct.Detail = product.Detail;
            dbproduct.Count = product.Count;
            dbproduct.Discount = product.Discount;
            dbproduct.DateDiscount = product.DateDiscount;
            dbproduct.CategorieID = product.CategorieID;
            dbproduct.BEST_SELLER = product.BEST_SELLER;
             dbproduct.RegularPrice = product.RegularPrice;
            dbproduct.MOST_VIEW = product.MOST_VIEW;
            dbproduct.NEW_ARRIVALS = product.NEW_ARRIVALS;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: HomeProductArea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: HomeProductArea/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Product dbproduct = await _context.Products.FindAsync(id);
            Utility.DeleteImageFromFolder(_env.WebRootPath, dbproduct.Image);
            _context.Products.Remove(dbproduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}