using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.Models
{
    public class AboutMe
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(400, ErrorMessage = "Length not more than 400 simbol")]
        public string Description { get; set; }
    }
}
