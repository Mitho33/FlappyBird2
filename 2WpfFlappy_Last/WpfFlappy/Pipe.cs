using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;//Notwendig für ImageBrush + BitMapImage
using System.Windows.Media.Imaging;

namespace WpfFlappy
{
    class Pipe : MainWindow
    {
        //Bildpimsel und Container für Bilder werden aus den entsprechenden Klassen erzeugt
        private ImageBrush saeuleUnten = new ImageBrush();//Bilder müssen in Ordner bin/debug sein für Uri
        private ImageBrush saeuleOben = new ImageBrush();

        
        private Canvas canvasPipeTop = new Canvas();
        private Canvas canvasPipeBottom = new Canvas();
        
        //Die Attribute werden mit der Get-Methode öffentlich anderen Klassen verfügbar gemacht
        public Canvas CanvasPipeTop
        { get { return canvasPipeTop; } }

        public Canvas CanvasPipeBottom
        { get { return canvasPipeBottom; } }

        //Mit der Konstruktormethode werden die Säulen bzw. deren Attribute initialisiert und anderen Klassen zur Verfügung gestellt
        public Pipe()
        {
            saeuleOben.ImageSource = new BitmapImage(new Uri(@"pipedown.png", UriKind.Relative));
            canvasPipeTop.Background = saeuleOben;
            canvasPipeTop.Height = Daten1.laengePipe;
            canvasPipeTop.Width = Daten1.breitePipe;

            saeuleUnten.ImageSource = new BitmapImage(new Uri(@"pipe.png", UriKind.Relative));
            canvasPipeBottom.Background = saeuleUnten;
            canvasPipeBottom.Height =Daten1.laengePipe;
            canvasPipeBottom.Width = Daten1.breitePipe;
        }

        public void Animiere()
        {
            Canvas.SetLeft(canvasPipeTop, 300);//300 entfernt vom linken Rand
            Canvas.SetBottom(canvasPipeTop, 438);//638-200, 438 vom Boden

            Canvas.SetLeft(canvasPipeBottom, 350);//350 von links
            Canvas.SetTop(canvasPipeBottom, 330);//330 von oben
            //Canvas.SetBottom(canvasPipeBottom, 470);
        }
            }
        }

 


   