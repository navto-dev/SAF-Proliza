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
    
    public partial class DetallesProductos
    {
        public int IdDetalle { get; set; }
        public int IdProducto { get; set; }
        public int IdInsumo { get; set; }
        public decimal CostoInsumo { get; set; }
    
        public virtual Insumos Insumos { get; set; }
        public virtual ProductosTerminados ProductosTerminados { get; set; }
    }
}
