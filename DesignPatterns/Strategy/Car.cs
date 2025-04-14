namespace DesignPatterns.Strategy
{
    public class  Car : IVehicle
    {
        public Car(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
