using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Models
{
    public class ShelterEdit
    {
        public int ShelterId { get; set; }
        public string ShelterName { get; set; }

        public int ZipCode { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public ShelterEdit()
        {

        }
    }

    
}
