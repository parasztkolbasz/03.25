using Betonkevero.Models;

namespace Betonkevero
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Keverotelep kevero = new Keverotelep("Kemény a beton Kft.");

            kevero.ReceptHozzaadasa(new Recept("C8/10", 1900, 250, 200));
            kevero.ReceptHozzaadasa(new Recept("C12/15", 1781, 315, 205));
            kevero.ReceptHozzaadasa(new Recept("C16/20", 1736, 350, 210));
            kevero.ReceptHozzaadasa(new Recept("C20/25", 1709, 380, 210));
            kevero.ReceptHozzaadasa(new Recept("C25/30", 1675, 400, 215));


            // Ezzel tesztelhet!
            // De előbb vegyen sódert és cementet! 
            // kevero.CementVasarlas(12000);
            // kevero.SoderVasarlas(30000);
            // RandomKeveresek(kevero, 5);


            while (true)
            {
                ConsoleKey mitSzeretne = MenuValasztas();
                Console.WriteLine();
                switch (mitSzeretne)
                {
                    case ConsoleKey.F1:
                        Console.WriteLine("Új recept hozzáadása");
                        ReceptHozzaadasa(kevero);
                        break;
                    case ConsoleKey.F2:
                        Console.WriteLine("Recept eltávolítása");
                        break;
                    case ConsoleKey.F3:
                        Console.WriteLine("Cement vásárlása");
                        break;
                    case ConsoleKey.F4:
                        Console.WriteLine("Sóder vásárlása");
                        break;
                    case ConsoleKey.F5:
                        Console.WriteLine("Keverés");
                        Console.WriteLine("Kérem válassza ki a receptet:");
                        int bekertszam= Convert.ToInt16(Console.ReadLine());
                        for (int i = 0; i < kevero.ReceptLista.Count; i++)
                        {
                            Console.WriteLine(kevero.ReceptLista);
                        }
                        // Itt a mintaképernyő szerint írassa ki a választékot és kérje be a választott recept indexét!
                        Console.Write("Mennyit szeretne keverni m3-ben? ");
                        double mennyit = double.Parse(Console.ReadLine());
                        // Itt hívja meg a keverő Kever() metódusát a kiválasztott recepttel és a megadott mennyiséggel!
                        // Alkalmazzon kivételkezelést a Kever() metódus hívásakor, hogy kezelje a lehetséges hibákat!
                        break;

                    case ConsoleKey.F6:
                        Console.WriteLine("Statisztikák lekérése");
                        Console.WriteLine(kevero);
                        Console.WriteLine($"Összesen előállított beton: {kevero.EddigKeszitettOsszesBeton()} m3");
                        Console.WriteLine($"Összesen felhasznált cement: {kevero.CementFelhasznalas()} kg");
                        Console.WriteLine($"Összesen felhasznált sóder: {kevero.SoderFelhasznalas()} kg");
                        Console.WriteLine($"Összesen felhasznált víz: {kevero.VizFelhasznalas()} liter");
                        break;
                    case ConsoleKey.F7:
                        Console.WriteLine("Eddigi keverések:");
                        // Listázza ki a keverő eddigi keveréseit a KeszbetonLista segítségével!
                        break;
                    case ConsoleKey.F12:
                        Console.WriteLine("Kilépés");
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás!");
                        break;
                }
            }
        }

        private static ConsoleKey MenuValasztas()
        {
            Console.WriteLine("\n\nMenüpontok\n");
            Console.WriteLine("[F1] Új recept hozzáadása");
            Console.WriteLine("[F2] Recept eltávolítása");
            Console.WriteLine("[F3] Cement vásárlása");
            Console.WriteLine("[F4] Sóder vásárlása");
            Console.WriteLine(new String('─', 30));
            Console.WriteLine("[F5] Keverés");
            Console.WriteLine(new String('─', 30));
            Console.WriteLine("[F6] Statisztikák lekérése");
            Console.WriteLine("[F7] Eddigi keverések");
            Console.WriteLine(new String('─', 30));
            Console.WriteLine("[F12] Kilépés");
            Console.Write("\nKérem válasszon egy menüpontot! ");
            while (!Console.KeyAvailable) ;
            return Console.ReadKey().Key;
        }

        private static void ReceptHozzaadasa(Keverotelep kevero)
        {
            Console.Write("Recept neve: ");
            string receptNev = Console.ReadLine();
            Console.Write("Sóder mennyisége kg-ban: ");
            int soder = int.Parse(Console.ReadLine());
            Console.Write("Cement mennyisége kg-ban: ");
            int cement = int.Parse(Console.ReadLine());
            Console.Write("Víz mennyisége literben: ");
            int viz = int.Parse(Console.ReadLine());
            kevero.ReceptHozzaadasa(new Recept(receptNev, soder, cement, viz));
        }

        private static void RandomKeveresek(Keverotelep kevero, int darab)
        {
            Random random = new Random();
            for (int i = 0; i < darab; i++)
            {
                int receptIndex = random.Next(kevero.ReceptLista.Count);
                double mennyit = Math.Round(random.NextDouble() * 150 + 1, 1);
                kevero.Kever(kevero.ReceptLista[receptIndex], mennyit);
            }
        }
    }
}
