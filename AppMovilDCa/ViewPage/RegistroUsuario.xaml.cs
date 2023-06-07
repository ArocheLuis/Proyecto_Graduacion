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
	public partial class RegistroUsuario : ContentPage
	{
		public RegistroUsuario ()
		{
			InitializeComponent ();
		}

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            //Ira la logica para capturar los datos
            
        }
    }
}