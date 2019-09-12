using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.Models
{
    public class RepeatTitleDesc
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"), StringLength(155, ErrorMessage = "Length not more than 155 simbol")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Required"),StringLength(400,ErrorMessage ="Length not more than 400 simbol")]
        public string Description { get; set; }
    }
}
