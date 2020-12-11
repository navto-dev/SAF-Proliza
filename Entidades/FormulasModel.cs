namespace Entidades
{
    public class FormulasModel
    {
        public int IdFormula { get; set; }
        public double Cantidad { get; set; }
        public int IdFamilia { get; set; }
        public string NombreFormula { get; set; }
        public string NombreFamilia { get; set; }
        public string UnidadMedida { get; set; }
        public string Capacidad { get; set; }
        public bool Activo { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
