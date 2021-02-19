using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Data
{
    //base class
    public class Pet
    {
        [Key]
        public Guid PetId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Breed { get; set; }

        public int? Age { get; set; }

        [Required]
        public string AboutMe { get; set; }
        //FK to adoption agency ID
    }
}
