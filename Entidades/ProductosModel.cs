namespace Entidades
{
    public class ProductosModel
    {
        public int IdFormula { get; set; }
        public int IdProducto { get; set; }
        public int IdDetalle { get; set; }
        public string NombreProducto { get; set; }
        public string UnidadMedida { get; set; }
        public string NombreFormula { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotalProducto { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }
    }
}
