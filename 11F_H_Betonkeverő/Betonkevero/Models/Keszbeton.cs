using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betonkevero.Models
{
    public class Keszbeton
    {
        Recept recept;
        DateTime keszitesIdeje;
        double mennyiseg; // m3-ben

        public Keszbeton(Recept recept, double mennyiseg)
        {
            this.recept = recept;
            this.mennyiseg = mennyiseg;
            this.keszitesIdeje = DateTime.Now;
        }

        public Recept Recept
        {
            get { return recept; }
        }

        public DateTime KeszitesIdeje
        {
            get { return keszitesIdeje; }
        }

        public double Mennyiseg
        {
            get { return mennyiseg; }
        }

        public override string? ToString()
        {
            return $"{recept.ReceptNev} - {mennyiseg} m3, készítve: {keszitesIdeje.ToShortDateString()}";
        }
    }
}
