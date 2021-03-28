using System;

namespace Entidades
{
    public class InsumosModel
    {

        public int IdInsumo { get; set; }
        public int IdProveedor { get; set; }
        public int IdFamilia { get; set; }
        public int IdMoneda { get; set; }
        public string NombreProveedor { get; set; }
        public string NombreInsumo { get; set; }
        public string NombreInterno { get; set; }
        public string UnidadMedida { get; set; }
        public string NombreFamilia { get; set; }
        public string NombreMoneda { get; set; }
        public DateTime FechaCompra { get; set; }
        public double PrecioUnitario { get; set; }
        public double TotalCompraMX { get; set; }
        /// <summary>
        /// Indica si al actualizar el costo del insumo se actualiza formulas y productos
        /// </summary>
        public bool ActualizaFormulas { get; set; }
        public int IdUsuario { get; set; }
    }
}
