using AppMovilDCa.Clases;
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
	public partial class Menu : ContentPage
	{
		public List<MenuCLS> listamenu { get; set;} 
		public Menu ()
		{
			InitializeComponent ();
            listamenu = new List<MenuCLS> ();
			listamenu.Add(new MenuCLS {nombreicono="ic_people",nombreitem="Persona" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_finca", nombreitem = "Finca" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_acti", nombreitem = "Actividad" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_pagos", nombreitem = "Pagos" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_informe", nombreitem = "Informe" });
            listamenu.Add(new MenuCLS { nombreicono = "ic_salir", nombreitem = "Salir" });
            BindingContext = this;
        }

        private void lstMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			//ya esta todo el objeto de la fila seleccionada
			MenuCLS omenuCLS = (MenuCLS)e.SelectedItem;
			switch(omenuCLS.nombreitem) 
			{
				case "Persona":
					App.Navigate.PushAsync(new Persona()); break;
                case "Finca":
                    App.Navigate.PushAsync(new Finca()); break;
				case "Actividad":
					App.Navigate.PushAsync(new Actividad()); break;
                case "Salir":
					App.Current.MainPage = new MainPage(); break;
            }
			App.MenuApp.IsPresented = false;
        }
    }
}