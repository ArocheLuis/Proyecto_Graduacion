using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AppMovilDCa.Clases
{
    public class EntityCLS : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<PersonaCLS> _listaPersona { get; set; }

        public List<PersonaCLS> listaPersona {
            get {
                return _listaPersona;
            }
            set {
            if (this._listaPersona != value) {
                    this._listaPersona = value;
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(this.listaPersona)));
                        }
            }
        }

        private List<FincaCLS> _listaFinca { get; set; }

        public List<FincaCLS> listaFinca
        {
            get
            {
                return _listaFinca;
            }
            set
            {
                if (this._listaFinca != value)
                {
                    this._listaFinca = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.listaFinca)));
                }
            }
        }
    }
}
