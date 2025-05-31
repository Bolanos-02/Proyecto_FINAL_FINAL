using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_de_clases;

namespace biblioteca_de_clases
{
    public class Cola
    {
        private NodoLista frente;
        private NodoLista fin;


        public Cola()
        {
            frente = fin = null;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(object dato)
        {
            NodoLista nuevo = new NodoLista(dato);
            if (EstaVacia())
            {
                frente = fin = nuevo;
            }
            else
            {
                fin.Siguiente = nuevo;
                fin = nuevo;
            }
        }

        public object Desencolar()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La cola está vacía.");

            object dato = frente.Dato;
            frente = frente.Siguiente;
            if (frente == null)
                fin = null;
            return dato;
        }

        public object Peek()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La cola está vacía.");

            return frente.Dato;
        }

        public string Recorrer()
        {
            string resultado = "";
            NodoLista actual = frente;
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
            NodoLista actual = frente;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        public void Vaciar()
        {
            frente = fin = null;
        }
    }
}