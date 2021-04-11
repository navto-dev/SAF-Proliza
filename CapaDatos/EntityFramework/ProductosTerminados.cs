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
    
    public partial class ProductosTerminados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductosTerminados()
        {
            this.DetallesProductos = new HashSet<DetallesProductos>();
        }
    
        public int IdProducto { get; set; }
        public int IdFormula { get; set; }
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotalProducto { get; set; }
        public bool Activo { get; set; }
        public Nullable<int> IdUsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public Nullable<int> IdUsuarioModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesProductos> DetallesProductos { get; set; }
        public virtual Formulas Formulas { get; set; }
    }
}