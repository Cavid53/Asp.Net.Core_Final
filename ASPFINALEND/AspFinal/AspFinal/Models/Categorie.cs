using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Required"),StringLength(200,ErrorMessage = "Length not more than 200 simbol")]
        public string  Name { get; set; }
        public string ActiveField { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
