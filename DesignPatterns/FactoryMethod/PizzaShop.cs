using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod
{
    public class PizzaShop
    {
        public Pizza CreateByName(string name) => name switch
        {
            "Margherita" => new Margherita(),
            "Funghi" => new Funghi(),
            "Salami" => new Salami(),
            _ => throw new ArgumentException($"Unknown pizza type: {name}"),
        };


        public Pizza CreateMargheritaPizza() => new Margherita();

        public Pizza CreateFunghiPizza() => new Funghi();

        public Pizza CreateSalamiPizza() => new Salami();

    }
}
