using DesignPatterns.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    public class PizzaExpress
    {
        // Statt eine konkrete Implementierung nutzen wir den abstrakten Typ IVehicle
        public IVehicle DeliveryStrategy { get; set; }

        public void Order(string name, int distanceInMeters)
        {
            var pizza = new PizzaShop().CreateByName(name);
            pizza.Prepare();
            pizza.Bake();

            SelectDeliveryStrategy(distanceInMeters);

            Deliver(pizza);
        }

        private void SelectDeliveryStrategy(int distanceInMeters)
        {
            if (distanceInMeters < 1000)
            {
                DeliveryStrategy = new Bike();
            }
            else if (distanceInMeters < 5000)
            {
                DeliveryStrategy = new Car("Fiat Punto");
            }
            else
            {
                DeliveryStrategy = new Drone();
            }
        }

        public void Deliver(Pizza pizza)
        {
            Console.WriteLine($"{pizza} mit {DeliveryStrategy.Name} wird geliefert");
        }
    }
}
