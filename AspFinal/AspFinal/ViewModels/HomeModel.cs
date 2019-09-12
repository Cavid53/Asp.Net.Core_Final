using AspFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.ViewModels
{
    public  class HomeModel
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<SingleFeature> SingleFeatures { get; set; }
        public IEnumerable<RepeatTitleDesc> RepeatTitleDescs { get; set; }
        public IEnumerable<BackgroundImage> BackgroundImages { get; set; }
        public IEnumerable<SingleCategorie> SingleCategories { get; set; }
        public IEnumerable<DealProduct> DealProducts { get; set; }
        public IEnumerable<ListProduct> ListProducts { get; set; }
        public IEnumerable<ListProductTitle> ListProductTitles { get; set; }
        public IEnumerable<AboutMe> AboutMes { get; set; }
        public IEnumerable<BrandCarusel> BrandCarusels { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
