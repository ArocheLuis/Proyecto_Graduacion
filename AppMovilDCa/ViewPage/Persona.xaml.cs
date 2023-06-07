using AppMovilDCa.Clases;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilDCa.ViewPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Persona : ContentPage
	{
        public static Persona instance;

        public EntityCLS oEntityCLS { get; set; }
        //public List<PersonaCLS> listaPersona { get; set; }
        //Ira la logica para manejar los datos de BD 
        private List<PersonaCLS> lista;

       public static Persona GetInstance()
        { 
			if (instance == null)
			{
				return new Persona();

            }
			else return instance;
		}
            public Persona ()
		{
            instance = this;
            InitializeComponent ();
            oEntityCLS= new EntityCLS ();
            oEntityCLS.listaPersona = new List<PersonaCLS>();
           /* oEntityCLS.listaPersona.Add(new PersonaCLS
            {
                IdPersona = 1,
                PrimerNombre = "Luis",
                SegundoNombre = "Eduardo",
                PrimerApellido = "Aroche",
                SegundoApellido = "Muralles",
                Telefono = 45457878,
                Direccion = "sa",
                Email = "12qw",
                Sexo = "masculino"
            });*/
            lista = oEntityCLS.listaPersona;
            BindingContext = this;
            listarPersonas();

        }

        private void lstPersona_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PersonaCLS objPersona=(PersonaCLS)e.SelectedItem;
			Navigation.PushAsync(new FormPersona(objPersona,"Editar Persona"));
        }

        private void toolbarAgregarr_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new FormPersona(new PersonaCLS(),"Agregar Persona"));
        }

        private void MenuEliminar_Clicked(object sender, EventArgs e)
        {
            MenuItem oMenuItem = sender as MenuItem;
            PersonaCLS oPersonaCLS = (PersonaCLS)oMenuItem.BindingContext;
        }

        private void searchPersona_TextChanged(object sender, TextChangedEventArgs e)
        {
            string valor = e.NewTextValue;
            if (valor == "") oEntityCLS.listaPersona = lista;
            else oEntityCLS.listaPersona = lista.Where(p => p.PrimerNombre.Contains(valor)).ToList();

        }
        public async void listarPersonas()
        {
            HttpClient cliente = new HttpClient();
            var rpta= await cliente.GetAsync("http://luisaroche-001-site1.atempurl.com/api/Persona");
            if (!rpta.IsSuccessStatusCode) oEntityCLS.listaPersona= new List<PersonaCLS>();
            else
            {
              var result= await rpta.Content.ReadAsStringAsync();
                List<PersonaCLS> l = JsonConvert.DeserializeObject<List<PersonaCLS>>(result);
                oEntityCLS.listaPersona = l;
            }
        }
    }
}