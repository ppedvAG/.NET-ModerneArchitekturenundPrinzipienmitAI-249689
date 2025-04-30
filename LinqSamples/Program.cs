using LinqSamples.Extensions;
using Serialization.Data;
using System.Drawing;
using System.Text;

namespace LinqSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 4711;
            var digitSum = MathExtensions.DigitSum(number);

            // als Extenson-Methode
            digitSum = number.DigitSum();

            Console.WriteLine($"Die Quersumme von {number} ist {digitSum}");

            List<Car> testData = Car.Generate(100);
            LinqSamples(testData);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void LinqSamples(IEnumerable<Car> vehicles)
        {
            Console.WriteLine("Top 10 vehicles");
            vehicles.Take(10)
                .ToList()
                .ForEach(Console.WriteLine);

            var averageSpeed = vehicles.Take(10).Average(v => v.TopSpeed);
            var maxSpeed = vehicles.Take(10).Max(v => v.TopSpeed);
            var minSpeed = vehicles.Take(10).Min(v => v.TopSpeed);
            Console.WriteLine($"Average speed: {averageSpeed} km/h, max speed: {maxSpeed} km/h, min speed: {minSpeed} km/h");

            // Exception wenn die Liste leer ist
            Console.WriteLine($"First car: {vehicles.First()}");

            // Null (default) wenn die Liste leer ist
            Console.WriteLine($"Last car: {vehicles.LastOrDefault()}");

            // Tipp: Besser Single als First (Wirft Exeption wenn Liste leer ist oder mehr als ein Eintrag gefunden wurde)
            // Warum? >> Fail-Fast: Was ist, wenn eine ID doch nicht eindeutig ist und es in den Daten Dupletten gibt?
            Console.WriteLine($"Single car: {vehicles.Single(v => v.Color == KnownColor.MediumVioletRed)}");

            Console.WriteLine("\n\nAlle Fahrzeuge mit einem rotem Farbton");
            vehicles.Where(v => v.Color.ToString().Contains("Red", StringComparison.OrdinalIgnoreCase))
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("\n\nTop 10 sortieren nach TopSpeed und Model.");
            vehicles
                .OrderByDescending(v => v.TopSpeed)
                .ThenBy(v => v.Model)
                .Take(10)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("\n\nAutos nach Treibstoffart gruppieren");
            IEnumerable<IGrouping<string, Car>> groups = vehicles.GroupBy(v => v.Fuel);
            groups.Select(g => new { g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList()
                .ForEach(g => Console.WriteLine($"{g.Count} Autos mit dem Treibstoff {g.Key}"));

            var startValue = new StringBuilder();
            var sb = vehicles
                .Skip(10)
                .Take(10)
                .Aggregate(startValue, AppendLine);
            Console.WriteLine(sb.ToString());

            // Lokale Funktion um Ausdruck wiederverwendbar zu machen
            static StringBuilder AppendLine(StringBuilder sb, Car c)
                => sb.AppendLine($"\tDer {c.Color} {c.Model} faehrt max. {c.TopSpeed} km/h.");

            Console.WriteLine("\n\nAutos nach Hersteller gruppieren");
            var dictionary = vehicles
                .Take(20)                
                .Select(c => new { Brand = c.Manufacturer, Vehicle = c })
                .GroupBy(c => c.Brand)
                .ToDictionary(g => g.Key, g => g.Select(c => c.Vehicle).Aggregate(new StringBuilder(), AppendLine).ToString());

            // IEnumerables sind lazy, d. h. die Linq Expressions werden erst bei den Methoden
            // ToList, ToArray oder ToDictionary ausgefuehrt
            var output = dictionary.Select(kvp =>
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                return kvp;
            });

            Console.WriteLine("\n\nEs wurde noch nichts in die Console geschrieben.");
            _ = output.ToArray();
        }
    }
}
