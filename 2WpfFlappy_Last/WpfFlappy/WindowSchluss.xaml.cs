using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Excel;

namespace WpfFlappy
{
    /// <summary>
    /// Interaktionslogik für WindowSchluss.xaml
    /// </summary>
    public partial class WindowSchluss : System.Windows.Window
    {
        MainWindow mw;
        ImageBrush vogel = new ImageBrush();
        public WindowSchluss()//Konstruktor für das Window
        {
            InitializeComponent();
            mw = new MainWindow();
            lblSchluss.Content = Convert.ToString(Daten1.counter1);
            vogel.ImageSource = new BitmapImage(new Uri(@"bird.png", UriKind.Relative));
            canvasBirdws.Background = vogel;
            canvasBirdws.Width = 60;
            canvasBirdws.Height = 50;

        }
     
        double max;
        double rang;
        
        private void CdbSchliessen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CdbRang_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //app.WindowState = XlWindowState.xlMaximized;

            Workbook wb = app.Workbooks.Open("E:\\WpfFlappy_8\\WpfFlappy\\bin\\Debug\\test.xlsx");//(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];

            mw = new MainWindow();
            rang = Daten1.counter1;
            ws.Range["D4"].Value = rang;

            if (ws.Range["D4"].Value > ws.Range["D3"].Value)
            {

                tbExcel.Text = Convert.ToString(ws.Range["d4"].Value);
            }
            else
            {
                tbExcel.Text = Convert.ToString(ws.Range["d3"].Value);

            }

            wb.SaveAs("E:\\WpfFlappy_8\\WpfFlappy\\bin\\Debug\\test.xlsx");
            wb.Close();
            app.Quit();

        }

        private void CdbRestart_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //app.WindowState = XlWindowState.xlMaximized;

            Workbook wb = app.Workbooks.Open("E:\\WpfFlappy_8\\WpfFlappy\\bin\\Debug\\test.xlsx");//(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            if (ws.Range["D4"].Value > ws.Range["D3"].Value)
            {

                ws.Range["D3"].Value = rang;
            }
          

                wb.SaveAs("E:\\WpfFlappy_8\\WpfFlappy\\bin\\Debug\\test.xlsx");
            wb.Close();
            app.Quit();

            Close();
            mw = new MainWindow();
            mw.ShowDialog();         
        }
    }
}
