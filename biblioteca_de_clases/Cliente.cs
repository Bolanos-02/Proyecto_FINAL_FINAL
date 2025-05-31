using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace biblioteca_de_clases
{
    public class Cliente : Comparador
    {
        public string DPI { get; set; }
        public string Nombre { get; set; }


        public Cliente(string dpi, string nombre)
        {
            DPI = dpi;
            Nombre = nombre;
        }

        public bool IgualQue(object obj)
        {
            Cliente otro = (Cliente)obj;
            return DPI == otro.DPI;
        }

        public bool MenorQue(object obj)
        {
            Cliente otro = (Cliente)obj;
            return string.Compare(DPI, otro.DPI) < 0;
        }

        public bool MenorIgualQue(object obj)
        {
            Cliente otro = (Cliente)obj;
            return string.Compare(DPI, otro.DPI) <= 0;
        }

        public bool MayorQue(object obj)
        {
            Cliente otro = (Cliente)obj;
            return string.Compare(DPI, otro.DPI) > 0;
        }

        public bool MayorIgualQue(object obj)
        {
            Cliente otro = (Cliente)obj;
            return string.Compare(DPI, otro.DPI) >= 0;
        }

        public override string ToString()
        {
            return $"({DPI} - {Nombre})";
        }
    }
}