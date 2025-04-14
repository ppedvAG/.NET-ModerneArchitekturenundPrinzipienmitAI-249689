using DesignPatterns.Adapter;
using DesignPatterns.BuilderPattern;
using DesignPatterns.Decorator;
using DesignPatterns.FactoryMethod;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sonderzeichen darstellen
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Factory Pattern:\nStandard-🍕 erzeugen");
            var pizzShop = new PizzaShop();
            var pizza = pizzShop.CreateByName("Margherita");
            Console.WriteLine(pizza);

            Console.WriteLine("\nBuilder Pattern:\tEigene 🍕 zusammenstellen");
            var builder = new PizzaConfigurator();
            var myPizza = builder
                .AddCheese()
                .AddPineapple()
                .AddHam()
                .Build();
            Console.WriteLine(myPizza);

            Console.WriteLine("\nDecorator Pattern:\t🍕 dekoriert");
            var boxedPizza = new BoxDecorator(new ExtraCheeseDecorator(myPizza));
            Console.WriteLine(boxedPizza);

            Console.WriteLine("\nStrategy Pattern:\t🍕 zustellen mit geeignetem Fahrzeug");
            var deliveryService = new PizzaExpress();
            deliveryService.Order("Margherita", 9000);

            Console.WriteLine("\nAdapter Pattern:\t🍕 in 🥘 backen");
            var panPizza = new PanPizzaAdapter(new PanPizza());
            Console.WriteLine(panPizza);

        }
    }
}
