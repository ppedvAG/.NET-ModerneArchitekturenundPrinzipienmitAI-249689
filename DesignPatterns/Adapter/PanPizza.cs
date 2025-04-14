using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public class PanPizza
    {
        public string Name => "NY Style Pfannen-Pizza";

        public void PutOilInPan()
        {
            Console.WriteLine("Put oil in pan");
        }

        public void FryInPan()
        {
            Console.WriteLine("Fry in pan");
        }
    }
}
