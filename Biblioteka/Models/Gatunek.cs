using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class Gatunek
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }

        public override string ToString() => Nazwa;
    }
}