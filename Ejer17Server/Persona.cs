using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejer17Server
{
    public class Persona
    {
        public String Nombre {get;set;}
        public String Apellidos { get; set; }
        public int Edad { get; set; }

        public Persona()
        {

        }

        public Persona(String _Nombre,String _Apellidos,int _Edad)
        {
            this.Nombre = _Nombre;
            this.Apellidos = _Apellidos;
            this.Edad = _Edad;
        }
    }
}