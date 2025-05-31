using biblioteca_de_clases;

namespace Api_Tarjetas.Estructuras
{
    public static class EstructuraGlobal
    {
        public static ArbolAVL ArbolClientes = new ArbolAVL();
        public static ListaEnlazada Movimientos = new ListaEnlazada();
        public static Pila Historial = new Pila();
        public static Cola Pendientes = new Cola();
        public static TablaHash TarjetasCredito = new TablaHash();
        public static TablaHash TablaResumenClientes = new TablaHash();
        public static TablaHash TablaTarjetas = new TablaHash(); // Clave = Número de tarjeta
    }
}