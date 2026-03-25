using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace Betonkevero.Models
{
    public class Keverotelep
    {
        List<Recept> receptLista;  // A keverőtelep által ismert receptek listája.
        String keveroNev;  // A keverőtelep neve.
        int soderKeszlet;  // Menny kg sóder van a telepen.
        int cementKeszlet;  // Menny kg cement van a telepen.

        List<Keszbeton> keszbetonLista;  // Az eddig elkészített betonkeverékek listája.

        public Keverotelep(string keveroNev)
        {
            // Haladó csoport ezt nem kapta meg!
            this.keveroNev = keveroNev;
            this.soderKeszlet = 0;
            this.cementKeszlet = 0;
            this.receptLista = new List<Recept>();
            this.keszbetonLista = new List<Keszbeton>();
        }

        public string KeveroNev { get => keveroNev; }
        public int SoderKeszlet { get => soderKeszlet; }
        public int CementKeszlet { get => cementKeszlet; }
        public List<Recept> ReceptLista { get => new List<Recept>(receptLista); }
        public List<Keszbeton> KeszbetonLista { get => new List<Keszbeton>(keszbetonLista); }
        public override string? ToString()
        {
            return $"Keverő neve: {keveroNev}, Készlet: {soderKeszlet} kg sóder, {cementKeszlet} kg cement, Eddigi keverékek száma: {keszbetonLista.Count}";
        }

        //Kezelje a kivétellel a következő eseteket:
        // - Negatív vagy nulla mennyiség megadása a keveréshez.
        // - Olyan recept megadása, amely nem szerepel a keverő receptjei között.
        // - Nem elegendő az alapanyag a keveréshez.
        public void Kever(Recept recept, double mennyiseg)
        {
            if (mennyiseg==0)
            {
                throw new Exception("Negatív vagy nulla mennyiség megadása a keveréshez");
            }
            else if (!receptLista.Contains(recept))
            {
                throw new Exception("Olyan recept megadása, amely nem szerepel a keverő receptjei között");
            }
            else 
            {
                receptLista.Add(recept);
            }
        }

        /// <summary>
        /// Lehetőség van sóder vásárlására, amely növeli a sóder készletet. Negatív vagy nulla mennyiség megadása esetén dobjon kivételt.
        /// </summary>
        /// <param name="soderMennyiseg">A vásárolni kívánt sóder mennyisége (kg)</param>
        public void SoderVasarlas(int soderMennyiseg)
        {
            if (soderMennyiseg <= 0)
            {
                throw new ArgumentException("Negatív vagy nulla mennyiség megadása a keveréshe");
            }
            else
            {
                this.soderKeszlet = soderMennyiseg;
            }
        }

        /// <summary>
        /// Lehetőség van cement vásárlására, amely növeli a cement készletet. Negatív vagy nulla mennyiség megadása esetén dobjon kivételt.
        /// </summary>
        /// <param name="cementMennyiseg">A vásárolni kívánt cement mennyisége (kg)</param>
        public void CementVasarlas(int cementMennyiseg)
        {
            if (cementMennyiseg <= 0)
            {
                throw new ArgumentException("Negatív vagy nulla mennyiség megadása a keveréshe");
            }
            else
            {
                this.cementKeszlet = cementMennyiseg;
            }
        }

        /// <summary>
        /// A telep működése óta felhasznált cement mennyisége kg-ban.
        /// </summary>
        /// <returns></returns>
        public int CementFelhasznalas()
        {
            int segedszam = 0;
            for (int i = 0; i < keszbetonLista.Count; i++)
            {
                segedszam += Convert.ToInt16(keszbetonLista[i].Recept.Cement * keszbetonLista[i].Mennyiseg);
            }
            return segedszam;
        }

        /// <summary>
        /// A telep működése óta felhasznált sóder mennyisége kg-ban.
        /// </summary>
        /// <returns></returns>
        public int SoderFelhasznalas()
        {
            int segedszam = 0;
            for (int i = 0; i < keszbetonLista.Count; i++)
            {
                segedszam += Convert.ToInt16(keszbetonLista[i].Recept.Soder * keszbetonLista[i].Mennyiseg);
            }
            return segedszam;
        }

        /// <summary>
        /// A telep működése óta felhasznált víz mennyisége literben.
        /// </summary>
        /// <returns></returns>
        public int VizFelhasznalas()
        {
            int segedszam = 0;
            for (int i = 0; i < keszbetonLista.Count; i++)
            {
                segedszam += Convert.ToInt16(keszbetonLista[i].Recept.Viz * keszbetonLista[i].Mennyiseg);
            }
            return segedszam;
        }

        /// <summary>
        /// Új recept hozzáadása a keverőtelep receptjei közé. 
        /// </summary>
        /// <param name="recept"></param>
        public void ReceptHozzaadasa(Recept recept)
        {
            receptLista.Add(recept);
        }

        /// <summary>
        /// Recept törlése a keverőtelep receptjei közül. Csak akkor törölhető egy recept, ha az nem szerepel egyetlen eddig elkészített betonkeverékben sem.
        /// </summary>
        /// <param name="recept"></param>
        public void ReceptTorlese(Recept recept)
        {
            receptLista.Remove(recept);
        }

        /// <summary>
        /// A telep működése óta elkészített összes beton mennyisége m3-ben.
        /// </summary>
        /// <returns></returns>
        public double EddigKeszitettOsszesBeton()
        {
            int szam = 0;
            for (int i = 0; i < keszbetonLista.Count; i++)
            {
                szam += Convert.ToInt16(keszbetonLista[i].Mennyiseg);
            }

            return szam;
        }
    }
}
