using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betonkevero.Models
{
    // 1 m3-ra vonatkozó arányokat tartalmazó osztály
    public class Recept
    {
        string receptNev;
        int soder; //kg
        int cement; //kg
        int viz; //liter

        public Recept(string receptNev, int soder, int cement, int viz)
        {
            this.receptNev = receptNev;
            this.soder = soder;
            this.cement = cement;
            this.viz = viz;
        }

        public string ReceptNev
        {
            get { return receptNev; }
            set { receptNev = value; }
        }

        public int Soder
        {
            get { return soder; }
        }

        public int Cement
        {
            get { return cement; }
        }

        public int Viz
        {
            get { return viz; }
        }

        public override string ToString()
        {
            return $"{receptNev}: Soder={soder} kg, Cement={cement} kg, Viz={viz} liter";
        }

        public int OsszSuly()
        {
            return soder + cement + viz;
        }
    }
}
