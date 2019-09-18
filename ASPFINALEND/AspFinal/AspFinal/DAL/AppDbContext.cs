using AspFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SingleFeature> SingleFeatures { get; set; }
        public DbSet<RepeatTitleDesc> RepeatTitleDescs { get; set; }
        public DbSet<BackgroundImage> BackgroundImages { get; set; }
        public DbSet<SingleCategorie> SingleCategories { get; set; }
        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<BrandCarusel> BrandCarusels { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
