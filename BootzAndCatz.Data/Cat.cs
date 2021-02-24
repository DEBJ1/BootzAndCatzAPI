﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Data
{
    //derived class
    public class Cat : Pet
    {
        [Key, Column(Order = 1)]
        public int CatId { get; set; }

        [Required]
        public bool IsDeclawed { get; set; }

        [Required]
        public bool IsFat { get; set; }
    }
}
