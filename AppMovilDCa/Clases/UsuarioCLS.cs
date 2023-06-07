using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppMovilDCa.Clases
{
    public class UsuarioCLS: INotifyPropertyChanged
    {
        private string _nombre { get; set; }
        private string _contra { get; set; }

        public string nombre { get 
            {
                   return _nombre;
            } 
            set 
            {
                if (this._nombre != value)
                {
                    this._nombre = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.nombre)));
                }
            } 
        }
        public string contra { get
            {
                return _contra;
            }
            set 
            {
                if (this._contra != value)
                {
                    this._contra = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.contra)));
                }
            }
                }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
