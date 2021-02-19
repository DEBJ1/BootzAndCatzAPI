using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Data
{
    public class Dog : Pet

    {
        [Key]
        public int DogId { get; set; }

        [Required]
        public bool IsChipped { get; set; }

        [Required]
        public string EnergyLevel { get; set; }

        [Required]
        public string Size { get; set; }
    }
}

