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
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace T153134
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<object> ViewModels
        //{
        //    get { return new ObservableCollection<object>((ObservableCollection<object>)GetValue(ViewModelsProperty)); }
        //    set { SetValue(ViewModelsProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ViewModels.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ViewModelsProperty =
        //    DependencyProperty.Register("ViewModels", typeof(ObservableCollection<object>), typeof(MainWindow), new PropertyMetadata(null));

        public Collection<object> ViewModels { get; set; } = new Collection<object>() { new MainGridViewModel(), new BlankTabViewModel() };

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await grid.LoadGrid();
            /*
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                var l = new List<object>() { new MainGridViewModel(), new BlankTabViewModel() };
                await Dispatcher.BeginInvoke(new Action(() => {
                    ViewModels = new ObservableCollection<object>();
                    ViewModels.Add(l[0]);
                    ViewModels.Add(l[1]);
                }
                ));
            });*/
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
