using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;


namespace biblioteca_de_clases
{
    public class Transaccion : Comparador
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // "Consumo" o "Pago"
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }

        public Transaccion(int id, string tipo, double monto)
        {
            Id = id;
            Tipo = tipo;
            Monto = monto;
            Fecha = DateTime.Now;
        }

        public bool IgualQue(object q)
        {
            return Id == ((Transaccion)q).Id;
        }

        public bool MenorQue(object q)
        {
            return Id < ((Transaccion)q).Id;
        }

        public bool MenorIgualQue(object q)
        {
            return Id <= ((Transaccion)q).Id;
        }

        public bool MayorQue(object q)
        {
            return Id > ((Transaccion)q).Id;
        }

        public bool MayorIgualQue(object q)
        {
            return Id >= ((Transaccion)q).Id;
        }

        public override string ToString()
        {
            return $"{Fecha.ToShortDateString()} - {Tipo} - Q{Monto}";
        }
    }
}