
using Solid.DIP;
using Solid.DIP.Payment;
using Solid.DIP.Shopping;
using Solid.ISP;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SampleISP();

            SampleDIP();
        }

        #region ISP Interface Segregation Principle
        private static void SampleISP()
        {
            var bunny = new Creature { Name = "Bunny", FavoriteFood = "Carrot 🥕🥕" };
            EatSomething(bunny);

            var jamieOliver = new Human { Name = "Jamie Oliver", FavoriteFood = "Pasta 🍝🍝" };
            PrepareFoodAndEat(jamieOliver);

            var duffy = CreateCreature<Creature>("Duffy", "🍕🍕🍕");
            duffy.Sleep();

        }

        private static void EatSomething(IEat eater)
        {
            eater.Eat();
        }

        public static void PrepareFoodAndEat_BadExample(IHuman human)
        {
            human.CookFood("🍕🍕🍕");
            human.Eat();
            human.Sleep();
        }

        public static void PrepareFoodAndEat<T>(T human)
            // Constraints fuer den generischen Typparameter T
            where T : IEat, ISleep, IChef
        {
            human.CookFood("🍕🍕🍕");
            human.Eat();
            human.Sleep();
        }

        public static T CreateCreature<T>(string name, string food)
            where T : class, IEat, new()
        {
            var creature = new T();
            creature.FavoriteFood = food;
            return creature;
        }
        #endregion

        private static void SampleDIP()
        {
            var payment = new PaymentService();
            var cart = new ShoppingCart(payment);

            cart.PayOrder();
        }
    }
}
