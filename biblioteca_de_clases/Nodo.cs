using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_de_clases
{
    public class Nodo
    {
        protected object Dato;
        protected Nodo Izquierdo;
        protected Nodo Derecho;

        // Constructor con valor
        public Nodo(object valor)
        {
            Dato = valor;
            Izquierdo = Derecho = null;
        }

        // Constructor con ramas
        public Nodo(Nodo ramaIzquierda, object valor, Nodo ramaDerecha)
        {
            Dato = valor;
            Izquierdo = ramaIzquierda;
            Derecho = ramaDerecha;
        }

        // Accesores
        public object ValorNodo()
        {
            return Dato;
        }

        public Nodo SubarbolIzdo()
        {
            return Izquierdo;
        }

        public Nodo SubarbolDcho()
        {
            return Derecho;
        }

        // Mutadores
        public void NuevoValor(object nuevoDato)
        {
            Dato = nuevoDato;
        }

        public void RamaIzdo(Nodo nodo)
        {
            Izquierdo = nodo;
        }

        public void RamaDcho(Nodo nodo)
        {
            Derecho = nodo;
        }

        public string Visitar()
        {
            return Dato.ToString();
        }
    }
}