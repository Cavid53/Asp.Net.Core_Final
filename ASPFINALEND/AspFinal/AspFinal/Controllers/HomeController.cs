using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspFinal.DAL;
using AspFinal.Models;
using AspFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspFinal.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeModel homeModel = new HomeModel
            {
                Sliders = _context.Sliders,
                SingleFeatures = _context.SingleFeatures,
                RepeatTitleDescs = _context.RepeatTitleDescs,
                BackgroundImages = _context.BackgroundImages,
                SingleCategories = _context.SingleCategories,
                AboutMes = _context.AboutMes,
                BrandCarusels = _context.BrandCarusels,
                Blogs = _context.Blogs,
                Products = _context.Products,
                Categories=_context.Categories.Include(x=>x.Products)
            };

            return View(homeModel);
        }
    }
}