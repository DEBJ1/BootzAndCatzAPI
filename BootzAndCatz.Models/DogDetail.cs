using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Models
{    //gather detail for list item 
    public class DogDetail
    {
        //info you see when you select specific dog 

        public int DogId { get; set; }

        public bool IsChipped { get; set; }

        public string EnergyLevel { get; set; }

        public string Size { get; set; }

        public string Name { get; set; }
        
        public string Breed { get; set; }

        public int Age { get; set; }
        
        public string AboutMe { get; set; }

    }
} ///Never give up
