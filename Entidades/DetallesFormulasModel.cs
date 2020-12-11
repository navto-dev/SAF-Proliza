namespace Entidades
{
    public class DetallesFormulasModel
    {
        public int IdDetalle { get; set; }
        public int IdFormula { get; set; }
        public int IdInsumo { get; set; }
        public string NombreFormula { get; set; }
        public string NombreInsumo { get; set; }
        public string NombreInterno { get; set; }
        public string UnidadMedidaInsumo { get; set; }
        public decimal CantidadInsumo { get; set; }
        public decimal CostoInsumo { get; set; }
        public bool Activo { get; set; }
        public decimal Precio { get; set; }
        public int IdUsuario { get; set; }
    }
}
