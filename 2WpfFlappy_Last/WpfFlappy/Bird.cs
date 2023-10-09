using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfFlappy
{
    class Bird : MainWindow//Klasse Bird erzeugt das Objekt Bird
    {   //Hier werden der Container Canvas und Bildpinsel aus den entsprechenden Klassen erzeugt
        Canvas canvasBird = new Canvas();//Wenn keine modifizier aufgeführt ist, dann gilt automatisch private
        ImageBrush vogel = new ImageBrush(); 

       public Canvas CanvasBird

        {
        get { return canvasBird; } 
       // set { canvasBird = value; } nicht notwendig, da keine Werte zurückgegeben werden
        } 

        public Bird()//Konstruktor mit Atrubuten /Eigenschaften für den Vogel

        {
            vogel.ImageSource = new BitmapImage(new Uri(@"bird.png", UriKind.Relative));//Bild wird geladen, muss vorher im Explorer deponiert werden
            //Bilder müssen in Ordner bin/debug sein für Uri
            canvasBird.Background = vogel;
            canvasBird.Width = 60;//Breite
            canvasBird.Height = 50;//Höhe
       
        }
        
        public void Flieg()//Methode: Anweisungen für den Bird
        {
           
            Canvas.SetLeft(canvasBird, 50);
            Canvas.SetTop(canvasBird, +Daten1.top);
            Canvas.SetRight(canvasBird, 110);//50+60
            Canvas.SetBottom(canvasBird,(Daten1.top+50));

        }


    }
        }

      