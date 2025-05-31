using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace biblioteca_de_clases
{
    public class Pila
    {
        private NodoLista cima;

        public Pila()
        {
            cima = null;
        }

        public bool EstaVacia()
        {
            return cima == null;
        }

        public void Push(object dato)
        {
            NodoLista nuevo = new NodoLista(dato);
            nuevo.Siguiente = cima;
            cima = nuevo;
        }

        public object Pop()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La pila está vacía.");

            object dato = cima.Dato;
            cima = cima.Siguiente;
            return dato;
        }

        public object Peek()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La pila está vacía.");

            return cima.Dato;
        }

        public string Recorrer()
        {
            string resultado = "";
            NodoLista actual = cima;
            while (actual != null)
            {
                resultado += actual.ToString() + "\n";
                actual = actual.Siguiente;
            }
            return resultado;
        }

        public int Contar()
        {
            int contador = 0;
            NodoLista actual = cima;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        public void Vaciar()
        {
            cima = null;
        }
    }
}