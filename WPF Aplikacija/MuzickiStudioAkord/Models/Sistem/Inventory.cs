using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    class Inventory
    {
        private List<Artikal> artikli;
        public List<Artikal> Artikli
        {
            get { return artikli; }
            set { artikli = value; }
        }

        public Inventory(List<Artikal> _artikli)
        {
            this.Artikli = _artikli;
        }
        public Inventory()
        {

        }


    }
}
