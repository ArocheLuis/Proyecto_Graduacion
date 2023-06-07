using AppMovilDCa.Clases;
using AppMovilDCa.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilDCa.ViewPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormFinca : ContentPage
    {
        public FincaCLS oFincaCLS {  get; set; } = new FincaCLS();
        public string titulo { get; set; }
        public FormFinca(FincaCLS obj, string nombretitulo)
        {
            InitializeComponent();
            oFincaCLS = obj;
            titulo = nombretitulo;
            BindingContext = this;
        }

        private async void GuardarFinca_Clicked(object sender, EventArgs e)
        {
         Finca obj = Finca.GetInstance();
         List<FincaCLS> l= obj.oEntityCLS.listaFinca.ToList();

            int rpta = await GenericLA.Post<FincaCLS>("http://luisaroche-001-site1.atempurl.com/api/Finca", oFincaCLS);
            if (rpta == 0) await DisplayAlert("Error", "Ocurrio un error en la BD", "Cancelar");
            else
            {
                await Navigation.PopAsync();
                obj.listarFincas();
            }
        

            /*if (titulo== "Agregar Finca")
            {
                l.Add(oFincaCLS);
               
            }
            else
            {
                int indice = l.FindIndex(p => p.IdFinca == oFincaCLS.IdFinca);
                l[indice] = oFincaCLS;
            }
            obj.oEntityCLS.listaFinca = l;
            Navigation.PopAsync();*/
        }

        private void Regresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}