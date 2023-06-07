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

    public partial class Finca : ContentPage
    {
       public static Finca instance;
       public EntityCLS oEntityCLS { get; set; }

        //public List<FincaCLS> listaFinca { get; set; }
        private List<FincaCLS> lista;
        //devuelve la instancia
        public static Finca GetInstance()
         {
             if (instance == null)
             {
                 return new Finca();

             }
             else return instance;
         }

        public Finca()
        { 

            instance = this;
            InitializeComponent();
            oEntityCLS = new EntityCLS();
            oEntityCLS.listaFinca = new List<FincaCLS>();
            //oEntityCLS.listaFinca.Add(new FincaCLS { IdFinca = 1, NombreFinca = "prueba", Ubicacion = "aprueba" });
            lista = oEntityCLS.listaFinca;
            BindingContext = this;
            listarFincas();
            
        }

        private void lstFinca_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FincaCLS objFinca = (FincaCLS)e.SelectedItem;
            Navigation.PushAsync(new FormFinca(objFinca,"Editar Finca"));
        }

        private void toolbarAgregarp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormFinca(new FincaCLS(), "Agregar Finca"));
        }

        private async void menuEliminar_Clicked(object sender, EventArgs e)
        {
            MenuItem oMenuItem = sender as MenuItem;
            FincaCLS oFincaCLS= (FincaCLS) oMenuItem.BindingContext;
            int IdFinca = oFincaCLS.IdFinca;
            int respuesta = await GenericLA.Delete("http://luisaroche-001-site1.atempurl.com/api/Finca" + IdFinca);
            if (respuesta == 0) await DisplayAlert("Error", "No se pudo eliminar", "Cancelar");
            else
            {
                listarFincas();
                await DisplayAlert("Exito", "Se ha eliminado con exito", "Cancelar");
            }
        }

        private void searchFinca_TextChanged(object sender, TextChangedEventArgs e)
        {
            string valor = e.NewTextValue;
            if (valor == "") oEntityCLS.listaFinca = lista;
            else oEntityCLS.listaFinca = lista.Where(p=>p.NombreFinca.Contains(valor)).ToList();
        }
        public async void listarFincas()
        {
            List<FincaCLS> l = await GenericLA.GetAll<FincaCLS>("http://luisaroche-001-site1.atempurl.com/api/Finca");
                oEntityCLS.listaFinca = l;
        }
    }
    
}