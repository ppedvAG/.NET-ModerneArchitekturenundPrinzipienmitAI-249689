using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Decorator
{
    public class PizzaDecorator : Pizza
    {
        private readonly Pizza _pizza;

        public PizzaDecorator(Pizza pizza) : base(pizza.Name)
        {
            _pizza = pizza;
        }
    }

    public class BoxDecorator : PizzaDecorator
    {
        public BoxDecorator(Pizza pizza) : base(pizza)
        {            
        }

        public override string Description => base.Description + ", in Schachtel verpackt";

    }

    public class ExtraCheeseDecorator : PizzaDecorator
    {
        public ExtraCheeseDecorator(Pizza pizza) : base(pizza)
        {            
        }

        public override string Description => base.Description + ", mit extra Käse";

        public override decimal GetCost() => base.GetCost() + 1.50m;
    }
}
