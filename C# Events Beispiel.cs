using System;

namespace Events_Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _WichtigeKlasse = new WichtigeKlasse();
            _WichtigeKlasse.MySuperEvent += _WichtigeKlasse_MySuperEvent;
            _WichtigeKlasse.DoSomeThing();
        }

        private static void _WichtigeKlasse_MySuperEvent(object sender, CostumEventArgs e)
        {
            //Mehr code
        }
    }
    internal class WichtigeKlasse
    {
        public event EventHandler<CostumEventArgs> MySuperEvent;

        public WichtigeKlasse()
        {
            MySuperEvent += EventGetriggered;
        }

        private void EventGetriggered(object sender, CostumEventArgs args)
        {
            if (args == null) return;
            Console.WriteLine(args.RandomInt); 
        }

        public void DoSomeThing()
        {
            /*
             * Code
             */
            Random rnd = new Random();
            int rndint = rnd.Next();
            CostumEventArgs args = new CostumEventArgs() { RandomInt = rndint };
            MySuperEvent?.Invoke(this, args);
        }
    }
    internal class CostumEventArgs
    {
        public int RandomInt { get; set; }
    }
}
