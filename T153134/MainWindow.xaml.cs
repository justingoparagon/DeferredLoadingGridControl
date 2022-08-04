using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using System.Windows.Threading;

namespace T153134
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action(() =>
            grid.LoadGrid();
            //));
        }

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    decorator.IsSplashScreenShown = true;
        //    PopulateChart(); // UI blocking action
        //    Dispatcher.BeginInvoke(new Action(() =>
        //    {
        //        decorator.IsSplashScreenShown = false;
        //    }), DispatcherPriority.Render);
        //}

        //private void PopulateChart()
        //{
        //    this.chartControl1.BeginInit();
        //    for (int i = 0; i < 2000; i++)
        //    {
        //        barSeries.Points.Add(new DevExpress.Xpf.Charts.SeriesPoint(i.ToString(), i * 2));
        //    }

        //    System.Threading.Thread.Sleep(3000);

        //    this.chartControl1.EndInit();
        //}

    }
}
