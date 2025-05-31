using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace biblioteca_de_clases
{
    public class ArbolBinario
    {
        protected Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public ArbolBinario(Nodo raiz)
        {
            this.raiz = raiz;
        }

        public Nodo RaizArbol()
        {
            return raiz;
        }

        public bool EsVacio()
        {
            return raiz == null;
        }

        public static Nodo NuevoArbol(Nodo ramaIzqda, object dato, Nodo ramaDrcha)
        {
            return new Nodo(ramaIzqda, dato, ramaDrcha);
        }

        public string Preorden() => Preorden(raiz);
        public string Inorden() => Inorden(raiz);
        public string Postorden() => Postorden(raiz);
        public int NumNodos() => NumNodos(raiz);

        private static string Preorden(Nodo r)
        {
            return r != null
                ? r.Visitar() + Preorden(r.SubarbolIzdo()) + Preorden(r.SubarbolDcho())
                : "";
        }

        private static string Inorden(Nodo r)
        {
            return r != null
                ? Inorden(r.SubarbolIzdo()) + r.Visitar() + Inorden(r.SubarbolDcho())
                : "";
        }

        private static string Postorden(Nodo r)
        {
            return r != null
                ? Postorden(r.SubarbolIzdo()) + Postorden(r.SubarbolDcho()) + r.Visitar()
                : "";
        }

        private static int NumNodos(Nodo raiz)
        {
            return raiz == null ? 0 : 1 + NumNodos(raiz.SubarbolIzdo()) + NumNodos(raiz.SubarbolDcho());
        }
    }
}