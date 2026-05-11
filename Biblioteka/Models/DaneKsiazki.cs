using System.Collections.Generic;

namespace Biblioteka.Models
{
    public class DaneKsiazki
    {
        public int       Id          { get; set; }
        public string    Tytul       { get; set; }
        public string    Wydawnictwo { get; set; }
        public int       GatunekId   { get; set; }
        public int       LiczbaStron { get; set; }
        public int       RokWydania  { get; set; }
        public decimal   Cena        { get; set; }
        public string    Opis        { get; set; }
        public List<int> AutorzyIds  { get; set; } = new List<int>();
    }
}
