using DesignPatterns.FactoryMethod;

namespace DesignPatterns.BuilderPattern
{
    public class PizzaConfigurator
    {
        private List<PizzaToppings> toppings = new();

        public PizzaConfigurator AddCheese()
        {
            toppings.Add(PizzaToppings.Cheese);
            return this;
        }

        public PizzaConfigurator AddPineapple()
        {
            toppings.Add(PizzaToppings.Pineapple);
            return this;
        }

        public PizzaConfigurator AddHam()
        {
            toppings.Add(PizzaToppings.Ham);
            return this;
        }

        public Pizza Build()
        {
            return new CustomPizza(toppings);
        }
    }
}
