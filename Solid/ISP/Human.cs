namespace Solid.ISP
{
    public class Human : Creature, IHuman
    {
        public void CookFood<T>(T value)
        {
            Console.WriteLine($"{Name} is cooking {value}");
        }
    }
}
