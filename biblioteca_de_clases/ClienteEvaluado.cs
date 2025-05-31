using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace biblioteca_de_clases
{
    public class ClienteEvaluado : Comparador
    {
        public int Carne { get; set; }
        public string Nombre { get; set; }
        public int Nota { get; set; }

        public ClienteEvaluado(int carne, string nombre, int nota)
        {
            Carne = carne;
            Nombre = nombre;
            Nota = nota;
        }

        public bool IgualQue(object obj)
        {
            ClienteEvaluado otro = (ClienteEvaluado)obj;
            return Carne == otro.Carne;
        }

        public bool MenorQue(object obj)
        {
            ClienteEvaluado otro = (ClienteEvaluado)obj;
            return Carne < otro.Carne;
        }

        public bool MenorIgualQue(object obj)
        {
            ClienteEvaluado otro = (ClienteEvaluado)obj;
            return Carne <= otro.Carne;
        }

        public bool MayorQue(object obj)
        {
            ClienteEvaluado otro = (ClienteEvaluado)obj;
            return Carne > otro.Carne;
        }

        public bool MayorIgualQue(object obj)
        {
            ClienteEvaluado otro = (ClienteEvaluado)obj;
            return Carne >= otro.Carne;
        }

        public override string ToString()
        {
            return $"({Carne} - {Nombre} - Nota: {Nota})";
        }
    }
}