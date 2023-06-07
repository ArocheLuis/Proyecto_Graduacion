using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilDCa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : MasterDetailPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
            App.Navigate = Navigations;
            App.MenuApp = this;
        }
    }
}