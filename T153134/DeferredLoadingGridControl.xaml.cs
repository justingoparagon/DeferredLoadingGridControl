using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace T153134
{
    /// <summary>
    /// Interaction logic for DeferredLoadingGridControl.xaml
    /// </summary>
    public partial class DeferredLoadingGridControl : GridControl
    {
        public LoadingDecorator Decorator
        {
            get { return (LoadingDecorator)GetValue(DecoratorProperty); }
            set { SetValue(DecoratorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Decorator.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecoratorProperty =
            DependencyProperty.Register("Decorator", typeof(LoadingDecorator), typeof(DeferredLoadingGridControl), new PropertyMetadata(null));

        public bool IsLoadingControls
        {
            get { return (bool)GetValue(IsLoadingControlsProperty); }
            set { SetValue(IsLoadingControlsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoadingControls.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingControlsProperty =
            DependencyProperty.Register("IsLoadingControls", typeof(bool), typeof(DeferredLoadingGridControl), new PropertyMetadata(true));

        public virtual ObservableCollection<Item> Items { get; set; } = GetItems();

        private static ObservableCollection<Item> GetItems()
        {
            var l = new List<Item>();

            for (int i = 0; i < 20000; i++)
            {
                l.Add(new Item() { ID = i + 1 });
            }

            return new ObservableCollection<Item>(l);
        }

        public DeferredLoadingGridControl()
        {
            //InitializeComponent();
        }

        public async Task LoadGrid()
        {
            await Task.Delay(100);

            await Task.Run(async () => await Dispatcher.BeginInvoke(new Action(() =>
            {
                var decorator = Decorator;
                //var decorator = (LoadingDecorator)Template.FindName("decorator1", this);

                //decorator.IsSplashScreenShown = true;

                InitializeComponent();

                //decorator.IsSplashScreenShown = false;

                //Dispatcher.BeginInvoke(new Action(() =>
                //    {
                //        decorator.IsSplashScreenShown = false;
                //    }), DispatcherPriority.Render);
            }
            )));
        }

        private void decorator1_Loaded(object sender, RoutedEventArgs e)
        {
            SetCurrentValue(DecoratorProperty, sender);
        }

        bool intermediary = false;

        private void myInternalGrid_Loaded(object sender, RoutedEventArgs e)
        {
            intermediary = IsLoadingControls = true;

            e.Handled = true;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }

        private void myInternalGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        bool firstUpdate = true;

        private async void myInternalGrid_LayoutUpdated(object sender, EventArgs e)
        {
            if (intermediary || firstUpdate)
            {
                //intermediary = isloadingcontrols = false;

                await Task.Delay(0);

                await Dispatcher.BeginInvoke(new Action(() =>
                firstUpdate = intermediary = IsLoadingControls = false
                ));
            }
        }

        private void TableView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void myInternalGrid_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void myInternalGrid_Initialized(object sender, EventArgs e)
        {

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

    public class Item
    {
        public int ID { get; set; } = 1;
        public string BigText { get; set; } = @"What is Lorem Ipsum? Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
Why do we use it?
It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
Where does it come from
Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, , comes from a line in section 1.10.32.
The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested.Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H.Rackham
Where can I get some
There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable.The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.";
    }
}
