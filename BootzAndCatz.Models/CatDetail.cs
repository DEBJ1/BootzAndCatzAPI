using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Models
{
    public class CatDetail
    {
        public int CatId { get; set; }

        public bool IsDeclawed { get; set; }

        public bool IsFat { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string AboutMe { get; set; }

    }
}
