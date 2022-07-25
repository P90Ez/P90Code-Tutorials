using System;

namespace Events_Tutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _WichtigeKlasse = new WichtigeKlasse();
            _WichtigeKlasse.MySuperEvent += _WichtigeKlasse_MySuperEvent; //Methode an Event "binden" (=> subscriben)
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
            MySuperEvent += EventGetriggered; //Methode an Event "binden" (=> subscriben)
        }

        private void EventGetriggered(object sender, CostumEventArgs args)
        {
            if (args == null) return; //Überprüfung
            Console.WriteLine(args.RandomInt); //Random Zahl in Console ausgeben lassen
        }

        public void DoSomeThing()
        {
            /*
             * Code
             */
            Random rnd = new Random();
            int rndint = rnd.Next();
            CostumEventArgs args = new CostumEventArgs() { RandomInt = rndint }; //EventArgs erstellen
            MySuperEvent?.Invoke(this, args); //Event "ausführen"
        }
    }
    internal class CostumEventArgs
    {
        public int RandomInt { get; set; }
    }
}
