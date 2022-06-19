using BarcodeScanner.Services;
using BarcodeScanner.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeScanner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<QrScanningService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
