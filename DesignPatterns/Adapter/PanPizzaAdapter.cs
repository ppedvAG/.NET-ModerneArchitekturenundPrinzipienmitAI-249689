using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Adapter
{
    /// <summary>
    /// Adapter fuer PanPizza welcher die Methoden "weiterleitet"
    /// </summary>
    public class PanPizzaAdapter : Pizza
    {
        private readonly PanPizza _panPizza;

        public PanPizzaAdapter(PanPizza panPizza) : base(panPizza.Name)
        {
            _panPizza = panPizza;
        }

        public override void Bake()
        {
            _panPizza.PutOilInPan();
            _panPizza.FryInPan();
        }
    }
}
