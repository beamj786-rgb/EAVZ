using System;

namespace GeneratorHesel
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. ÚVOD A NASTAVENÍ DÉLKY
            Console.WriteLine("=== GENERÁTOR BEZPEČNÝCH HESEL ===");
            Console.WriteLine("Zadejte požadovanou délku hesla:");

            int delka;
            string vstupDelka = Console.ReadLine();

            if (!int.TryParse(vstupDelka, out delka) || delka <= 0)
            {
                Console.WriteLine("Neplatný vstup, nastavuji výchozí délku 12 znaků.");
                delka = 12;
            }

            // 2. DOTAZY NA PARAMETRY
            Console.WriteLine("Chcete velká písmena? (a/n)");
            bool pouzitVelka = Console.ReadLine().ToLower() == "a";

            Console.WriteLine("Chcete čísla? (a/n)");
            bool pouzitCisla = Console.ReadLine().ToLower() == "a";

            Console.WriteLine("Chcete speciální znaky? (a/n)");
            bool pouzitSpeciální = Console.ReadLine().ToLower() == "a";

            // 3. PŘÍPRAVA SADY ZNAKŮ (POOL)
            string sadaZnaku = "abcdefghijklmnopqrstuvwxyz"; // základ: malá písmena

            if (pouzitVelka) sadaZnaku += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (pouzitCisla) sadaZnaku += "0123456789";
            if (pouzitSpeciální) sadaZnaku += "!@#$%&*+?_-";

            // 4. SAMOTNÉ GENEROVÁNÍ
            Random rnd = new Random();
            string vysledneHeslo = "";

            for (int i = 0; i < delka; i++)
            {
                // Vybereme náhodný index z naší sady
                int index = rnd.Next(0, sadaZnaku.Length);

                // Přidáme znak na tomto indexu k heslu
                vysledneHeslo += sadaZnaku[index];
            }

            // 5. VÝSTUP
            Console.WriteLine("\n-------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vaše nové heslo: " + vysledneHeslo);
            Console.ResetColor();
            Console.WriteLine("-------------------------------");

            Console.WriteLine("\nStiskněte libovolnou klávesu pro ukončení...");
            Console.ReadKey();
        }
    }
}