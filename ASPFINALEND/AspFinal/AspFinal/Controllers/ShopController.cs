using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspFinal.DAL;
using Microsoft.AspNetCore.Mvc;

namespace AspFinal.Controllers
{
    public class ShopController : Controller
    {
        private AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View(_context.Categories);
        }
    }
}