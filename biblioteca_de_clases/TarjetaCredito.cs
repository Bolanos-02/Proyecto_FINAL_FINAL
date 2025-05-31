using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_de_clases
{
    public class TarjetaCredito
    {
        public string Numero { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public string Pin { get; set; }
        public string Estado { get; set; }  // Activo, Bloqueado, etc.
        public string DPI { get; set; }     // Relación con el cliente

        public TarjetaCredito(string numero, double limite, string pin, string dpi)
        {
            Numero = numero;
            Saldo = 0;
            Limite = limite;
            Pin = pin;
            Estado = "Activo";
            DPI = dpi;
        }

        public override string ToString()
        {
            return $"Tarjeta: {Numero}, Saldo: {Saldo}, Límite: {Limite}, Estado: {Estado}, Cliente: {DPI}";
        }
    }
}