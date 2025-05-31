using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace biblioteca_de_clases
{
    public class ListaEnlazada
    {
        private NodoLista primero;

        public ListaEnlazada()
        {
            primero = null;
        }

        public bool EstaVacia()
        {
            return primero == null;
        }

     
        public void InsertarInicio(object dato)
        {
            NodoLista nuevo = new NodoLista(dato);
            nuevo.Siguiente = primero;
            primero = nuevo;
        }

        public void InsertarFinal(object dato)
        {
            NodoLista nuevo = new NodoLista(dato);
            if (EstaVacia())
            {
                primero = nuevo;
            }
            else
            {
                NodoLista actual = primero;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public void InsertarFinal(object clave, object dato)
        {
            NodoLista nuevo = new NodoLista(clave, dato);
            if (EstaVacia())
            {
                primero = nuevo;
            }
            else
            {
                NodoLista actual = primero;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public NodoLista Buscar(object clave)
        {
            NodoLista actual = primero;
            while (actual != null)
            {
                if (actual.Clave != null && actual.Clave.ToString() == clave.ToString())
                    return actual;

                actual = actual.Siguiente;
            }
            return null;
        }

        public string Recorrer()
        {
            string resultado = "";
            NodoLista actual = primero;
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
            NodoLista actual = primero;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        public void Vaciar()
        {
            primero = null;
        }

        public NodoLista Primero => primero;
    }
}