namespace CapaNegocios
{
    public static class ConversorUnidades
    {
        public static decimal Kilos_Gramos(decimal Cantidad) => Cantidad * 1000;
        public static decimal Gramos_Miligramos(decimal Cantidad) => Cantidad * 1000;
        public static decimal Kilos_Miligramos(decimal Cantidad) => Cantidad * 1000000;

        public static decimal Litros_Mililitros(decimal Cantidad) => Cantidad * 1000;



    }
}
