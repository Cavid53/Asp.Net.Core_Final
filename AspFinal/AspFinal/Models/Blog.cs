using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(155, ErrorMessage = "Length not more than 155 simbol")]
        public string Title1 { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(155, ErrorMessage = "Length not more than 155 simbol")]
        public string Title2 { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(250, ErrorMessage = "Length not more than 250 simbol")]
        public string Image { get; set; }
    }
}
