using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT2A_databaze
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazev { get; set; }
        public string Vyrobce { get; set; }
        public int RokVyroby { get; set; }
        public string Kategorie { get; set; }
        public int PocetKusu { get; set; }
        public bool JeDostupny { get; set; }
    }
}
