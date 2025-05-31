using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace biblioteca_de_clases
{
    public class ResumenCliente : Comparador
    {
        public int Carne { get; set; }
        public string Nombre { get; set; }
        public int Cargos { get; set; }
        public int Abonos { get; set; }

        public ResumenCliente(int carne, string nombre)
        {
            Carne = carne;
            Nombre = nombre;
            Cargos = 0;
            Abonos = 0;
        }

        public void AgregarCargo(int monto) => Cargos += monto;
        public void AgregarAbono(int monto) => Abonos += monto;

        public override string ToString()
        {
            return $"Cliente: {Nombre} ({Carne})\nCargos: Q{Cargos}\nAbonos: Q{Abonos}\nSaldo: Q{Abonos - Cargos}";
        }

        
        public bool IgualQue(object q) => Carne == ((ResumenCliente)q).Carne;
        public bool MenorQue(object q) => Carne < ((ResumenCliente)q).Carne;
        public bool MenorIgualQue(object q) => Carne <= ((ResumenCliente)q).Carne;
        public bool MayorQue(object q) => Carne > ((ResumenCliente)q).Carne;
        public bool MayorIgualQue(object q) => Carne >= ((ResumenCliente)q).Carne;
    }
}