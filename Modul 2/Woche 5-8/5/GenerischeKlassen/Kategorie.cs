using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GenerischeKlassen
{
    public class Kategorie
    {
        public string Bezeichnung { get; set; }

        public override string ToString()
        {
            return Bezeichnung;
        }
    }
}
