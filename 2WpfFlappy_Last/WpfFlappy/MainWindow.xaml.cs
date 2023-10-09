using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace WpfFlappy
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
       

        public MainWindow()//Konstrukor für Steuerelemente, deshalb timer hier
        {
            InitializeComponent();

            timer.Tick += new EventHandler(timer_Tick);//Event Handler sorgt dafür das jedes Ereignis von MainWindow bei jedem Tick die Funktion neu ausführt
            timer.Interval = TimeSpan.FromSeconds(0.1);//Intervalldauer
            timer.Tick += timer_Tick;
        }

        WindowSchluss wss;//Auswertungsfenster

        DispatcherTimer timer = new DispatcherTimer();//erst nach dem Konstruktor wird das Objekt  Dispatcher Timer erzeugt, sonst wird unten den timer.Start nicht erkannt

        private double linksOberePipe;//Variablen für den Crash
        private double linksUnterePipe;
        private double bodenOberePipe;
        private double topUnterePipe;//Variablen für den Crash
        private double counter;//Zähler für statischen Zähler
    
        


        public double Counter
        { get { return counter; }
        }

        
        Bird bird;
        Pipe pipe;
        ImageBrush boom;
        private void CmbErstellen_Click(object sender, RoutedEventArgs e)
        {
            //Methode zur Erstellung der Objekte bird und Säulen in Canvas1
            bird = new Bird();
            bird.Flieg();
            canvas1.Children.Add(bird.CanvasBird);

            pipe = new Pipe();
            pipe.Animiere();
            canvas1.Children.Add(pipe.CanvasPipeTop);
            canvas1.Children.Add(pipe.CanvasPipeBottom);
        }

        public static void Pause(double zeit)
        {
            double zeit1 = System.Environment.TickCount;
            double zeit2;
            do
            {
                zeit2 = System.Environment.TickCount;
                System.Windows.Forms.Application.DoEvents(); //Verweis für System.Windows.Forms hinzufügen, rechte Maustaste Projektexplorer WpfFlappy, Hinzufügen, Verweis, Assemblys!
            } while (zeit2 - zeit1 < zeit);
        }

        void timer_Tick(object sender, EventArgs e)//Methode startet den timer
         
        {
           
            counter++;//Zählt bei jedem Tick einen mehr
            lblCounter.Content = Convert.ToString(counter);
           Daten1.counter1 = counter;


            double top1 = (double)bird.CanvasBird.GetValue(Canvas.TopProperty);//top1 erhält immer den neuesten Positionswert vom bird
            bird.CanvasBird.SetValue(Canvas.TopProperty, top1 + Daten1.speed);//Position Bird sinkt immer um den speed z. B. 5, Achtung sinken + auf der y-Achse
          

            if (top1 >= Daten1.boden)//Untersuchung, ob Kollision mit dem Boden stattgefunden hat
            {
                //wenn der obere Wert des Vogels um  unter 470 gesunken ist, wechselt der Hintergrund auf ib und der timmer stoppt 
                boom = new ImageBrush();
                boom.ImageSource = new BitmapImage(new Uri(@"explosion.png", UriKind.Relative));
                bird.CanvasBird.Background = boom;
                timer.Stop();
                Pause(500);
                this.Close();//Mit dem this-Verweis wird auf die Instanz referiert (Bezug genommen) von der die Methode aufgerufen wurde, hier MainWindow
                //timer wird im MainWindow durch den Konstruktor initialisiert
                wss = new WindowSchluss();
                 wss.ShowDialog();
            }

            double rechtsVogel = (double)bird.CanvasBird.GetValue(Canvas.RightProperty);
            double untenVogel = (double)bird.CanvasBird.GetValue(Canvas.BottomProperty);

            linksOberePipe = (double)pipe.CanvasPipeTop.GetValue(Canvas.LeftProperty);//Positionswerte müssen in double umgewandelt werden und werden aktualisiert
            pipe.CanvasPipeTop.SetValue(Canvas.LeftProperty, linksOberePipe - Daten1.speed);//Positionswerte werden wie beim bird um den speed erhöht, aktuell 5, Minus, da Pipe nach links wandert

            bodenOberePipe = (double)pipe.CanvasPipeTop.GetValue(Canvas.BottomProperty);
            pipe.CanvasPipeTop.SetValue(Canvas.BottomProperty, bodenOberePipe);

            linksUnterePipe = (double)pipe.CanvasPipeBottom.GetValue(Canvas.LeftProperty);//holt den Wert und wandelt ihn in double um
            pipe.CanvasPipeBottom.SetValue(Canvas.LeftProperty, linksUnterePipe - Daten1.speed);//verändert Wert um 5 nach oben und gibt ihn zurück

            topUnterePipe = (double)pipe.CanvasPipeBottom.GetValue(Canvas.TopProperty);
            // pipe.CanvasPipeBottom.SetValue(Canvas.TopProperty, top);

            if (rechtsVogel == linksOberePipe && top1<=Daten1.laengePipe)//Länge Pipe bis Ende Canvas, Kollisionsabfrage
                {
                    boom = new ImageBrush();
                    boom.ImageSource = new BitmapImage(new Uri(@"explosion.png", UriKind.Relative));
                    bird.CanvasBird.Background = boom;
                    timer.Stop();
                Pause(500);
                this.Close();
                    wss = new WindowSchluss();
                    wss.ShowDialog();
            }

          
            if (rechtsVogel == linksUnterePipe && top1+30>=283)//+50 für Höhe Vogel 200 Höhe Pipe und 105 Boden, Gesamt 638, 30 wegen top
            {
                boom = new ImageBrush();
                boom.ImageSource = new BitmapImage(new Uri(@"explosion.png", UriKind.Relative));
                bird.CanvasBird.Background = boom;
                timer.Stop();
                Pause(500);
                this.Close();
                wss = new WindowSchluss();
                wss.ShowDialog();

            }
          
            if ((double)pipe.CanvasPipeTop.GetValue(Canvas.LeftProperty) < 0)
                {
                    pipe.CanvasPipeTop.SetValue(Canvas.LeftProperty, linksOberePipe = 480);

                }
                //s. o.
                if ((double)pipe.CanvasPipeBottom.GetValue(Canvas.LeftProperty) < 0)
                {
                    pipe.CanvasPipeBottom.SetValue(Canvas.LeftProperty, linksUnterePipe = 480);
                }          
        }

            private void CmbStart_Click(object sender, RoutedEventArgs e)   
            {
                timer.Start();
            }

        //Tastaturbelegung und Sprunghöhe 

        public void Window_KeyDown(object sender, KeyEventArgs e)
            {
                double top1 = (double)bird.CanvasBird.GetValue(Canvas.TopProperty);//aktuelle Wert wird ermittelt

                if (e.Key == Key.Space)
                {
                    bird.CanvasBird.SetValue(Canvas.TopProperty, top1 - Daten1.speed);
                }
            }

            public void Window_KeyUp(object sender, KeyEventArgs e)
            {
                double top1 = (double)bird.CanvasBird.GetValue(Canvas.TopProperty);//aktuelle Wert wird ermittelt

                if (e.Key == Key.Space)
                {
                    bird.CanvasBird.SetValue(Canvas.TopProperty, top1 + Daten1.speed);
                }
            }
        }
    }

























