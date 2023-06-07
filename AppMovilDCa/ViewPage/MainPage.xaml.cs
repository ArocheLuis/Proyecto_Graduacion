using AppMovilDCa.Clases;
using AppMovilDCa.ViewPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovilDCa
{
    public partial class MainPage : ContentPage
    {
        public UsuarioCLS ousuarioCLS { get; set; } = new UsuarioCLS();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new RegistroUsuario());
        }

        private async void toolbarAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }


        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            if (ousuarioCLS.nombre=="L" && ousuarioCLS.contra=="12")
            {
                Application.Current.MainPage = new PaginaPrincipal();
            }
            else
            {
                DisplayAlert("Error","Contrasenia o usuario incorrecto", "Aceptar");
            }
           
        }

        private void btnAsignar_Clicked(object sender, EventArgs e)
        {
            ousuarioCLS.nombre = "L";
            ousuarioCLS.contra = "12";
        }
    }
}
