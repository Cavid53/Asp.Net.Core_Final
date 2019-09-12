﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspFinal.Models
{
    public class SingleCategorie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Required"),StringLength(255,ErrorMessage ="Length not more than 155 simbol")]
        public string Image { get; set; }
    }
}
