//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Insumos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Insumos()
        {
            this.DetallesFormulas = new HashSet<DetallesFormulas>();
            this.DetallesProductos = new HashSet<DetallesProductos>();
        }
    
        public int IdInsumo { get; set; }
        public int IdProveedor { get; set; }
        public string NombreInsumo { get; set; }
        public string NombreInterno { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalCompraMX { get; set; }
        public System.DateTime FechaCompra { get; set; }
        public int IdFamilia { get; set; }
        public int IdMoneda { get; set; }
        public bool Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesFormulas> DetallesFormulas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesProductos> DetallesProductos { get; set; }
        public virtual FamiliaInsumos FamiliaInsumos { get; set; }
    }
}