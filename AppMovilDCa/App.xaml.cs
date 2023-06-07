using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilDCa
{
    public partial class App : Application
    {
        public static NavigationPage Navigate { get; internal set; }
        public static PaginaPrincipal MenuApp { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
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
