using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    /// <summary>
    /// Model użytkownika do wyświetlania w listach
    /// </summary>
    public class UzytkownikListItem
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string ImieNazwisko { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{ImieNazwisko} ({Login}) - {Email}";
        }
    }
}
