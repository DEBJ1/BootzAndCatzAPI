using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Data
{
    public class Shelter
    {
        [Key]
        public string ShelterName { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }


        //[ForeignKey(nameof(Cat))]
        //public int CatId { get; set; }
        //public virtual Cat Cat { get; set; }

        //[ForeignKey(nameof(Dog))]
        //public int DogId { get; set; }
        //public virtual Dog Dog { get; set; }
    }
}
