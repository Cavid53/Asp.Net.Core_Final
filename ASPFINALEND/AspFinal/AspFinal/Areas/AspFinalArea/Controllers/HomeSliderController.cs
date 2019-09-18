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

namespace AspFinal.Areas.AspFinalArea.Controllers
{
    [Area("AspFinalArea")]
    public class HomeSliderController : Controller
    {
        private AppDbContext _context;
        private IHostingEnvironment _env;
        public HomeSliderController(AppDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: HomeSlider
        public IActionResult Index()
        {
            return View(_context.Sliders);
        }

        // GET: HomeSlider/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        // GET: HomeSlider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeSlider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (ModelState["Title"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }

            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "This is not photo");
                return View();
            }

            if (!slider.Photo.CheckImageSize(1))
            {
                ModelState.AddModelError("Photo", "Image size not more than 1 MB");
                return View();
            }

            string filename = await slider.Photo.CopyImage(_env.WebRootPath, "slider");

            slider.Image = filename;
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        // GET: HomeSlider/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View(slider);
        }

        // POST: HomeSlider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            Slider dbslider = await _context.Sliders.FindAsync(id);
            if (dbslider == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (ModelState["Title"].ValidationState == ModelValidationState.Invalid ||
                ModelState["Description"].ValidationState == ModelValidationState.Invalid )
            {
                return View(dbslider);
            }

            if (slider.PhotoUpdate != null)
            {
                if (!slider.PhotoUpdate.IsImage())
                {
                    ModelState.AddModelError("Photo", "This is not photo");
                    return View();
                }
                if (!slider.PhotoUpdate.CheckImageSize(1))
                {
                    ModelState.AddModelError("Photo", "Image size not more than 1 MB");
                    return View();

                }
                string filename = await slider.PhotoUpdate.CopyImage(_env.WebRootPath, "slider");
                Utility.DeleteImageFromFolder(_env.WebRootPath, dbslider.Image);

                dbslider.Image = filename;
            }
            dbslider.Title = slider.Title;
            dbslider.Description = slider.Description;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: HomeSlider/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        // POST: HomeSlider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            Utility.DeleteImageFromFolder(_env.WebRootPath, slider.Image);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
