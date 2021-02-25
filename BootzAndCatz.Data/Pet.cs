using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Data
{
    //base class
    public abstract class Pet
    {
     
        [Required]
        public string Name { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        public string AboutMe { get; set; }
        //FK to adoption agency ID

        [ForeignKey("Shelter")]
        public int ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
}
