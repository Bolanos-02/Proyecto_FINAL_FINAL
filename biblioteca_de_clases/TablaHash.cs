using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace biblioteca_de_clases
{
    public class TablaHash
    {
        private const int TAMANIO = 23;
        private ListaEnlazada[] tabla;

        public TablaHash()
        {
            tabla = new ListaEnlazada[TAMANIO];
            for (int i = 0; i < TAMANIO; i++)
            {
                tabla[i] = new ListaEnlazada();
            }
        }

        private int FuncionHash(object clave)
        {
            return Math.Abs(clave.GetHashCode() % TAMANIO);
        }

        public void Insertar(object clave, object valor)
        {
            int posicion = FuncionHash(clave);

            var yaExiste = tabla[posicion].Buscar(clave);
            Console.WriteLine($"Insertando clave {clave} en posición {posicion} - ¿Ya existe?: {(yaExiste != null)}");

            if (yaExiste != null)
                throw new Exception("No puede haber claves repetidas");

            tabla[posicion].InsertarFinal(clave, valor);
        }

        public object Buscar(object clave)
        {
            int posicion = FuncionHash(clave);
            NodoLista nodo = tabla[posicion].Buscar(clave);
            return nodo?.Dato;
        }

        public string MostrarTodo()
        {
            string resultado = "";
            for (int i = 0; i < TAMANIO; i++)
            {
                resultado += $"[{i}]:\n";
                resultado += tabla[i].Recorrer() + "\n";
            }
            return resultado;
        }

        public void Vaciar()
        {
            for (int i = 0; i < TAMANIO; i++)
            {
                tabla[i].Vaciar();
            }
        }
    }
}