using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Models
{
    public class CatCreate
    {
        //properties needed to POST a cat

        [Required]
        public bool IsDeclawed { get; set; }

        [Required]
        public bool IsFat { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [MinLength(50, ErrorMessage = "Please enter at least 1 characters.")]
        [MaxLength(2000, ErrorMessage = "There are too many characters in this field.")]
        public string AboutMe { get; set; }
    }
}
