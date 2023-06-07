using AppMovilDCa.Clases;
using AppMovilDCa.Generic;
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
    public partial class FormPersona : ContentPage
    {
        public PersonaCLS oPersonaCLS {  get; set; }= new PersonaCLS();
        public string titulo { get; set; }
        public FormPersona(PersonaCLS obj, string nombretitulo)
        {
            InitializeComponent();
            oPersonaCLS = obj;
            titulo = nombretitulo;
            BindingContext = this;
           
        }

        private async void GuardarPersona_Clicked(object sender, EventArgs e)
        {
            Persona obj = Persona.GetInstance();
            List<PersonaCLS> l = obj.oEntityCLS.listaPersona.ToList();

            int rpta = await GenericLA.Postp<PersonaCLS>("http://luisaroche-001-site1.atempurl.com/api/Persona", oPersonaCLS);
            if (rpta == 0) await DisplayAlert("Error", "Ocurrio un error en la BD", "Cancelar");
            else
            {
                await Navigation.PopAsync();
                obj.listarPersonas();
            }
        }

        private void Regresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

       
    }
}