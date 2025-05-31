using Microsoft.AspNetCore.Mvc;
using biblioteca_de_clases;
using Api_Tarjetas.Estructuras;
using System;

namespace biblioteca_de_clases
{
    public class TarjetaCredito
    {
        public string Numero { get; set; }
        public string DpiCliente { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public int PIN { get; set; }
        public string Estado { get; set; }

        public TarjetaCredito(string numero, string dpiCliente, double limite, int pin)
        {
            Numero = numero;
            DpiCliente = dpiCliente;
            Limite = limite;
            Saldo = limite; // Asumimos que el saldo inicial es el límite
            PIN = pin;
            Estado = "Activa";
        }

        public void AgregarConsumo(double monto)
        {
            if (Estado != "Activa")
                throw new InvalidOperationException("La tarjeta no está activa.");
            if (Saldo < monto)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= monto;
        }

        public void AgregarPago(double monto)
        {
            if (Estado != "Activa")
                throw new InvalidOperationException("La tarjeta no está activa.");

            Saldo += monto;
            if (Saldo > Limite)
                Saldo = Limite; // No puede exceder el límite
        }

        public override string ToString()
        {
            return $"Número: {Numero}, DPI: {DpiCliente}, Saldo: Q{Saldo}, Límite: Q{Limite}, Estado: {Estado}";
        }
    }
}