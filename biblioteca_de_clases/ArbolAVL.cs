using System;

namespace biblioteca_de_clases
{
    public class ArbolAVL
    {
        protected NodoAvl raiz;

        public ArbolAVL()
        {
            raiz = null;
        }

        public NodoAvl Raiz => raiz;

        private NodoAvl RotacionII(NodoAvl n, NodoAvl n1)
        {
            n.RamaIzdo(n1.SubarbolDcho());
            n1.RamaDcho(n);

            if (n1.Fe == -1)
            {
                n.Fe = 0;
                n1.Fe = 0;
            }
            else
            {
                n.Fe = -1;
                n1.Fe = 1;
            }
            return n1;
        }

        private NodoAvl RotacionDD(NodoAvl n, NodoAvl n1)
        {
            n.RamaDcho(n1.SubarbolIzdo());
            n1.RamaIzdo(n);

            if (n1.Fe == +1)
            {
                n.Fe = 0;
                n1.Fe = 0;
            }
            else
            {
                n.Fe = +1;
                n1.Fe = -1;
            }
            return n1;
        }

        private NodoAvl RotacionID(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2 = (NodoAvl)n1.SubarbolDcho();
            n.RamaIzdo(n2.SubarbolDcho());
            n2.RamaDcho(n);
            n1.RamaDcho(n2.SubarbolIzdo());
            n2.RamaIzdo(n1);

            if (n2.Fe == +1) n1.Fe = -1;
            else n1.Fe = 0;

            if (n2.Fe == -1) n.Fe = 1;
            else n.Fe = 0;

            n2.Fe = 0;
            return n2;
        }

        private NodoAvl RotacionDI(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2 = (NodoAvl)n1.SubarbolIzdo();
            n.RamaDcho(n2.SubarbolIzdo());
            n2.RamaIzdo(n);
            n1.RamaIzdo(n2.SubarbolDcho());
            n2.RamaDcho(n1);

            if (n2.Fe == +1) n.Fe = -1;
            else n.Fe = 0;

            if (n2.Fe == -1) n1.Fe = 1;
            else n1.Fe = 0;

            n2.Fe = 0;
            return n2;
        }

        public void Insertar(object valor)
        {
            Comparador dato = (Comparador)valor;
            Logical h = new Logical(false);
            raiz = InsertarAvl(raiz, dato, h);
        }

        private NodoAvl InsertarAvl(NodoAvl r, Comparador dt, Logical h)
        {
            NodoAvl n1;
            if (r == null)
            {
                r = new NodoAvl(dt);
                h.SetLogical(true);
            }
            else if (dt.MenorQue(r.ValorNodo()))
            {
                NodoAvl iz = InsertarAvl((NodoAvl)r.SubarbolIzdo(), dt, h);
                r.RamaIzdo(iz);

                if (h.BooleanValue())
                {
                    switch (r.Fe)
                    {
                        case 1:
                            r.Fe = 0;
                            h.SetLogical(false);
                            break;
                        case 0:
                            r.Fe = -1;
                            break;
                        case -1:
                            n1 = (NodoAvl)r.SubarbolIzdo();
                            r = (n1.Fe == -1) ? RotacionII(r, n1) : RotacionID(r, n1);
                            h.SetLogical(false);
                            break;
                    }
                }
            }
            else if (dt.MayorQue(r.ValorNodo()))
            {
                NodoAvl dr = InsertarAvl((NodoAvl)r.SubarbolDcho(), dt, h);
                r.RamaDcho(dr);

                if (h.BooleanValue())
                {
                    switch (r.Fe)
                    {
                        case 1:
                            n1 = (NodoAvl)r.SubarbolDcho();
                            r = (n1.Fe == +1) ? RotacionDD(r, n1) : RotacionDI(r, n1);
                            h.SetLogical(false);
                            break;
                        case 0:
                            r.Fe = +1;
                            break;
                        case -1:
                            r.Fe = 0;
                            h.SetLogical(false);
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("No puede haber claves repetidas");
            }
            return r;
        }

        public void Eliminar(object valor)
        {
            Comparador dato = (Comparador)valor;
            Logical flag = new Logical(false);
            raiz = BorrarAvl(raiz, dato, flag);
        }

        private NodoAvl BorrarAvl(NodoAvl r, Comparador clave, Logical cambiaAltura)
        {
            if (r == null)
                throw new Exception("Nodo no encontrado");

            if (clave.MenorQue(r.ValorNodo()))
            {
                NodoAvl iz = BorrarAvl((NodoAvl)r.SubarbolIzdo(), clave, cambiaAltura);
                r.RamaIzdo(iz);
                if (cambiaAltura.BooleanValue()) r = Equilibrar1(r, cambiaAltura);
            }
            else if (clave.MayorQue(r.ValorNodo()))
            {
                NodoAvl dr = BorrarAvl((NodoAvl)r.SubarbolDcho(), clave, cambiaAltura);
                r.RamaDcho(dr);
                if (cambiaAltura.BooleanValue()) r = Equilibrar2(r, cambiaAltura);
            }
            else
            {
                NodoAvl q = r;
                if (q.SubarbolIzdo() == null)
                {
                    r = (NodoAvl)q.SubarbolDcho();
                    cambiaAltura.SetLogical(true);
                }
                else if (q.SubarbolDcho() == null)
                {
                    r = (NodoAvl)q.SubarbolIzdo();
                    cambiaAltura.SetLogical(true);
                }
                else
                {
                    NodoAvl iz = Reemplazar(r, (NodoAvl)r.SubarbolIzdo(), cambiaAltura);
                    r.RamaIzdo(iz);
                    if (cambiaAltura.BooleanValue()) r = Equilibrar1(r, cambiaAltura);
                }
                q = null;
            }
            return r;
        }

        private NodoAvl Reemplazar(NodoAvl n, NodoAvl act, Logical cambiaAltura)
        {
            if (act.SubarbolDcho() != null)
            {
                NodoAvl d = Reemplazar(n, (NodoAvl)act.SubarbolDcho(), cambiaAltura);
                act.RamaDcho(d);
                if (cambiaAltura.BooleanValue()) act = Equilibrar2(act, cambiaAltura);
            }
            else
            {
                n.NuevoValor(act.ValorNodo());
                act = (NodoAvl)act.SubarbolIzdo();
                cambiaAltura.SetLogical(true);
            }
            return act;
        }

        private NodoAvl Equilibrar1(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
            switch (n.Fe)
            {
                case -1: n.Fe = 0; break;
                case 0:
                    n.Fe = 1;
                    cambiaAltura.SetLogical(false);
                    break;
                case +1:
                    n1 = (NodoAvl)n.SubarbolDcho();
                    if (n1.Fe >= 0)
                    {
                        if (n1.Fe == 0) cambiaAltura.SetLogical(false);
                        n = RotacionDD(n, n1);
                    }
                    else
                    {
                        n = RotacionDI(n, n1);
                    }
                    break;
            }
            return n;
        }

        private NodoAvl Equilibrar2(NodoAvl n, Logical cambiaAltura)
        {
            NodoAvl n1;
            switch (n.Fe)
            {
                case -1:
                    n1 = (NodoAvl)n.SubarbolIzdo();
                    if (n1.Fe <= 0)
                    {
                        if (n1.Fe == 0) cambiaAltura.SetLogical(false);
                        n = RotacionII(n, n1);
                    }
                    else
                    {
                        n = RotacionID(n, n1);
                    }
                    break;
                case 0:
                    n.Fe = -1;
                    cambiaAltura.SetLogical(false);
                    break;
                case +1:
                    n.Fe = 0;
                    break;
            }
            return n;
        }

        public string Inorden() => Inorden(raiz);
        public string Preorden() => Preorden(raiz);
        public string Postorden() => Postorden(raiz);

        private string Inorden(Nodo r)
        {
            if (r != null)
                return Inorden(r.SubarbolIzdo()) + r.Visitar() + Inorden(r.SubarbolDcho());
            return "";
        }

        private string Preorden(Nodo r)
        {
            if (r != null)
                return r.Visitar() + Preorden(r.SubarbolIzdo()) + Preorden(r.SubarbolDcho());
            return "";
        }

        private string Postorden(Nodo r)
        {
            if (r != null)
                return Postorden(r.SubarbolIzdo()) + Postorden(r.SubarbolDcho()) + r.Visitar();
            return "";
        }

        public int ContarNodos() => ContarNodos(raiz);

        private int ContarNodos(Nodo r)
        {
            if (r == null) return 0;
            return 1 + ContarNodos(r.SubarbolIzdo()) + ContarNodos(r.SubarbolDcho());
        }

        public bool EsVacio() => raiz == null;
    }
}