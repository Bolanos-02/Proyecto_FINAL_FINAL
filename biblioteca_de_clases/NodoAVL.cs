using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_de_clases
{
    public class NodoAvl : Nodo
    {
        public int Fe { get; set; }

        public NodoAvl(object valor) : base(valor)
        {
            Fe = 0;
        }

        public NodoAvl(object valor, NodoAvl ramaIzdo, NodoAvl ramaDcho)
            : base(ramaIzdo, valor, ramaDcho)
        {
            Fe = 0;
        }
    }
}
