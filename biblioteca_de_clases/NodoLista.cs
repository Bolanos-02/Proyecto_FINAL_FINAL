using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_de_clases
{
    public class NodoLista
    {
        public object Clave { get; set; }
        public object Dato { get; set; }
        public NodoLista Siguiente { get; set; }

        public NodoLista(object dato)
        {
            Clave = null;
            Dato = dato;
            Siguiente = null;
        }

        public NodoLista(object clave, object dato)
        {
            Clave = clave;
            Dato = dato;
            Siguiente = null;
        }

        public override string ToString()
        {
            return Clave != null ? $"{Clave}: {Dato}" : Dato.ToString();
        }
    }
}