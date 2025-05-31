using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_de_clases
{
    public class Logical
    {
        private bool valor;

        public Logical(bool valorInicial)
        {
            valor = valorInicial;
        }

        public void SetLogical(bool nuevoValor)
        {
            valor = nuevoValor;
        }

        public bool BooleanValue()
        {
            return valor;
        }
    }
}