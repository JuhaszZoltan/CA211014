using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211014
{
    class Program
    {
        static List<Jatekos> jatekosok = new List<Jatekos>();
        static void Main()
        {
            Beolvas();
            Console.WriteLine($"3. feladat: játékosok száma: {jatekosok.Count}");
            int fordulokSzama = jatekosok[0].Tippek.Length;
            Console.WriteLine($"4. feladat: fordulók száma: {fordulokSzama}");
            bool volt = jatekosok.Any(x => x.Tippek[0] == 1);
            Console.WriteLine($"5. feladat: Az első fortulóban {(volt ? "volt" : "nem volt")} 1es tipp");
            int max = jatekosok.Max(x => x.Tippek.Max());
            Console.WriteLine($"6. feladat: Legnagyobb tipp a fordulók során: {max}");
            Console.Write($"7. feladat: Kérem a forduló sorszámát [1-{fordulokSzama}]: ");
            int ip = int.Parse(Console.ReadLine());
            int fs = ip <= fordulokSzama && ip >= 1 ? ip : 1;
            var egyediTippek = jatekosok
                .Select(x => x.Tippek[fs - 1])
                .GroupBy(x => x)
                .Where(x => x.Count() == 1);

            if (egyediTippek.Count() == 0)
            {
                Console.WriteLine("8. feladat: nincs nyertes");
                Console.WriteLine("9. feladat: nincs nyertes");
            }
            else
            {
                var nyertesTipp = egyediTippek.Min(x => x.Key);
                Console.WriteLine($"8. feladat: a nyertes tipp a megadott fordulóban: {nyertesTipp}");
                var nyertesNev = jatekosok
                    .Where(x => x.Tippek[fs - 1] == nyertesTipp)
                    .First().Nev;
                Console.WriteLine($"9. feladat: a megadott forduló nyertese: {nyertesNev}");

                using (var sw = new StreamWriter(@"..\..\res\nyertes.txt", false, Encoding.UTF8))
                {
                    sw.WriteLine($"Forduló sorszáma: {fs}");
                    sw.WriteLine($"Nyertes tipp: {nyertesTipp}");
                    sw.WriteLine($"Nyertes játékos: {nyertesNev}");
                }
            }

            Console.ReadKey();
        }

        private static void Beolvas()
        {
            using (var sr = new StreamReader(@"..\..\res\egyszamjatek.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream) jatekosok.Add(new Jatekos(sr.ReadLine()));
            }
        }
    }
}
