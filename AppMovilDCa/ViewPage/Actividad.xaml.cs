using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilDCa.ViewPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actividad : ContentPage
    {
        public Actividad()
        {
            InitializeComponent();
        }

        private void creaActividad_Clicked(object sender, EventArgs e)
        {
            App.Navigate.PushAsync(new Empleado());
        }
    }
}