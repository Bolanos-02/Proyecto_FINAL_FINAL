using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace biblioteca_de_clases
{
    public class ArbolBinarioBusqueda : ArbolBinario
    {
        public ArbolBinarioBusqueda() : base()
        {
        }

        public ArbolBinarioBusqueda(Nodo nodo) : base(nodo)
        {
        }

        public Nodo Buscar(object buscado)
        {
            Comparador dato = (Comparador)buscado;
            if (raiz == null)
                return null;
            else
                return Buscar(raiz, dato);
        }

        protected Nodo Buscar(Nodo raizSub, Comparador buscado)
        {
            if (raizSub == null)
                return null;
            else if (buscado.IgualQue(raizSub.ValorNodo()))
                return raizSub;
            else if (buscado.MenorQue(raizSub.ValorNodo()))
                return Buscar(raizSub.SubarbolIzdo(), buscado);
            else
                return Buscar(raizSub.SubarbolDcho(), buscado);
        }

        public Nodo BuscarIterativo(object buscado)
        {
            Comparador dato = (Comparador)buscado;
            Nodo actual = raiz;
            while (actual != null)
            {
                if (dato.IgualQue(actual.ValorNodo()))
                    return actual;
                else if (dato.MenorQue(actual.ValorNodo()))
                    actual = actual.SubarbolIzdo();
                else
                    actual = actual.SubarbolDcho();
            }
            return null;
        }

        public void Insertar(object valor)
        {
            Comparador dato = (Comparador)valor;
            raiz = Insertar(raiz, dato);
        }

        protected Nodo Insertar(Nodo raizSub, Comparador dato)
        {
            if (raizSub == null)
                return new Nodo(dato);
            else if (dato.MenorQue(raizSub.ValorNodo()))
            {
                Nodo iz = Insertar(raizSub.SubarbolIzdo(), dato);
                raizSub.RamaIzdo(iz);
            }
            else if (dato.MayorQue(raizSub.ValorNodo()))
            {
                Nodo dr = Insertar(raizSub.SubarbolDcho(), dato);
                raizSub.RamaDcho(dr);
            }
            else
            {
                throw new Exception("Nodo duplicado");
            }
            return raizSub;
        }

        public void Eliminar(object valor)
        {
            Comparador dato = (Comparador)valor;
            raiz = Eliminar(raiz, dato);
        }

        protected Nodo Eliminar(Nodo raizSub, Comparador dato)
        {
            if (raizSub == null)
                throw new Exception("No se encontró el nodo con la clave");

            if (dato.MenorQue(raizSub.ValorNodo()))
            {
                Nodo iz = Eliminar(raizSub.SubarbolIzdo(), dato);
                raizSub.RamaIzdo(iz);
            }
            else if (dato.MayorQue(raizSub.ValorNodo()))
            {
                Nodo dr = Eliminar(raizSub.SubarbolDcho(), dato);
                raizSub.RamaDcho(dr);
            }
            else
            {
                // Nodo encontrado
                if (raizSub.SubarbolIzdo() == null)
                    return raizSub.SubarbolDcho();
                else if (raizSub.SubarbolDcho() == null)
                    return raizSub.SubarbolIzdo();
                else
                    raizSub = Reemplazar(raizSub);
            }
            return raizSub;
        }

        private Nodo Reemplazar(Nodo act)
        {
            Nodo padre = act;
            Nodo actual = act.SubarbolIzdo();
            while (actual.SubarbolDcho() != null)
            {
                padre = actual;
                actual = actual.SubarbolDcho();
            }

            act.NuevoValor(actual.ValorNodo());

            if (padre == act)
                padre.RamaIzdo(actual.SubarbolIzdo());
            else
                padre.RamaDcho(actual.SubarbolIzdo());

            return act;
        }
    }
}