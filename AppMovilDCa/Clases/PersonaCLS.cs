using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilDCa.Clases
{
    public class PersonaCLS
    {
        public int IdPersona { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public int Telefono { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public int BHabilitado { get; set; }

        public int BTieneUsuario { get; set; }
    }
}
