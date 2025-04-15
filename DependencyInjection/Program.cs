using DependencyInjection.Application;
using DependencyInjection.Application.Attributes;
using DependencyInjection.Application.Services;
using DependencyInjection.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = RegisterTypesOnApplicationStartup();

            var service = serviceProvider.GetService<IShoppingCartService>();
            service.AddProduct(new Product("Kaffee", 1.99m));
            service.PayOrder();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static ServiceProvider RegisterTypesOnApplicationStartup()
        {
            var container = new ServiceCollection();

            // Bei Transient wird jedes mal eine neue Instanz des Services erzeugt // var service = new ShoppingCartService();
            container.AddTransient<IShoppingCartService, ShoppingCartService>();

            // Bei Scoped wird die Instanz des Services nur einmal pro Request bzw. beim Ausloesen den Abhaengigkeitsbaumes
            container.AddScoped<IPaymentService, PaymentService>();

            // Bei Singleton wird die Instanz einmal waehrend des gesamten Lebenzykluses der Anwendung erzeugt
            container.AddSingleton<AppSettings>();


            // Alternative Idee: Ueber ServiceAttribute iterieren
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<ServiceAttribute>() != null)
                .ToList().ForEach(t => container.AddTransient(t));

            var serviceProvider = container.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
