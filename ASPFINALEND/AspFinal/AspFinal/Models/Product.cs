using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(255, ErrorMessage = "Length not more than 255 simbol")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(450, ErrorMessage = "Length not more than 450 simbol")]
        public string Detail { get; set; }
        [Required(ErrorMessage ="Required")]
        public int Count { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(255, ErrorMessage = "Length not more than 255 simbol")]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [NotMapped]
        public IFormFile PhotoUpdate { get; set; }
        public int Discount { get; set; }
        [Required(ErrorMessage ="Required")]
        public double RegularPrice { get; set; }
        public string DateDiscount { get; set; }
        public string ActiveField { get; set; }
        public bool NEW_ARRIVALS { get; set; }
        public int MOST_VIEW { get; set; }
        public int BEST_SELLER { get; set; }
        public int CategorieID { get; set; }
        
        public virtual Categorie Categorie { get; set; }

    }
}
