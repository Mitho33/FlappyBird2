using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFlappy
{
    public static class Daten1//statische Attribute oder Methoden könnne ohne Objekt aufgrufen werden, nur unter Angabe der Klasse
    {
       public static double  counter1;
        public static double speed=5;//Geschwindigkeit von Bird und Säule 120 ist gute Alternative
        public static double boden = 470;
        public static double laengePipe = 200;
        public static double breitePipe = 60;
        public static double top = 100;//Abstand zum oberen Rand von Canvas1
    }
}
