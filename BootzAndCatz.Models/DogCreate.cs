using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Models
{
    public class DogCreate
    {
        //items required for creating a dog 
        [Required]
        public bool IsChipped { get; set; }

        [Required]
        public string EnergyLevel { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Breed { get; set; }

        public int Age { get; set; }

        [Required]
        public string AboutMe { get; set; }

        public int ShelterId { get; set; }
    }
}

