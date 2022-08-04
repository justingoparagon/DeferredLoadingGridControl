using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace T153134 {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
        }

        private async void decorator_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var s = sender as LoadingDecorator;

                var a = s.Child as DeferredLoadingGridControl;

                await a.LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
