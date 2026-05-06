namespace Biblioteka.Models
{
    public class Autor
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public override string ToString() => $"{Imie} {Nazwisko}";
    }
}
