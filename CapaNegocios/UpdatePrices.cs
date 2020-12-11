using CapaNegocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class UpdatePrices
    {
        CNDetallesFormulas Detalle = new CNDetallesFormulas();
        CNDetallesProductos DEtalleP = new CNDetallesProductos();
        //CNInsumos Insumo = new CNInsumos();
        CNProductos Producto = new CNProductos();
        CNFormulas Formula = new CNFormulas();
        List<int> listaFormulas = new List<int>();
        List<int> listaProductos = new List<int>();
        int IdInsumo;
        decimal PrecioInsumo;
        double PrecioDetalles;
        double dolar;

        double CalculaPrecioUnitarioProducto(int IdFormula, int IdProducto)
        {
            #region "Calcula PrecioUnitario Formula"
            DataRow PrecioFormula = Formula.ConsultaPorId(IdFormula).Rows[0];
            double CostoTotal = Convert.ToDouble(PrecioFormula["CostoTotal"]);
            string UnidadMedidaFormula = Convert.ToString(PrecioFormula["Capacidad"]);
            int Cantidad = Convert.ToInt32(PrecioFormula["Cantidad"]);
            double CostoUnitario = 0;
            switch (UnidadMedidaFormula.ToUpper())
            {
                case "LITROS":
                    CostoUnitario = CostoTotal / Cantidad;
                    break;
                case "MILILITROS":
                    CostoUnitario = (1000 * CostoTotal) / Cantidad;
                    break;
                case "KILOGRAMOS":
                    CostoUnitario = CostoTotal / Cantidad;
                    break;
                case "GRAMOS":
                    CostoUnitario = (1000 * CostoTotal) / Cantidad;
                    break;
                case "MILIGRAMOS":
                    CostoUnitario = (10000 * CostoTotal) / Cantidad;
                    break;
            }
            #endregion
            DataRow listaProducto = Producto.ConsultaConsultaPorId(IdProducto).Rows[0];
            PrecioDetalles = Convert.ToDouble(listaProducto["CostoTotalProducto"]) - Convert.ToDouble(listaProducto["CostoUnitario"]);
            string UnidadMedida = Convert.ToString(listaProducto["UnidadMedida"]);
            double CantidadProducto = Convert.ToInt32(listaProducto["Cantidad"]);
            double PrecioProducto = 0;
            switch (UnidadMedida.ToUpper())
            {
                case "LITROS":
                    PrecioProducto = CostoUnitario * CantidadProducto;
                    break;
                case "MILILITROS":
                    PrecioProducto = (1000 * CostoUnitario) / CantidadProducto;
                    break;
                case "KILOGRAMOS":
                    PrecioProducto = CostoUnitario * CantidadProducto;
                    break;
                case "GRAMOS":
                    PrecioProducto = (1000 * CostoUnitario) / CantidadProducto;
                    break;
                case "MILIGRAMOS":
                    PrecioProducto = (10000 * CostoUnitario) / CantidadProducto;
                    break;
            }
            return PrecioProducto;
        }
        double CalculaPrecioUnitarioFormula(int IdFormula)
        {
            #region "Calcula PrecioUnitario Formula"
            DataRow PrecioFormula = Formula.ConsultaPorId(IdFormula).Rows[0];
            double CostoTotal = Convert.ToDouble(PrecioFormula["CostoTotal"]);
            string UnidadMedidaFormula = Convert.ToString(PrecioFormula["Capacidad"]);
            int Cantidad = Convert.ToInt32(PrecioFormula["Cantidad"]);
            double CostoUnitario = 0;
            switch (UnidadMedidaFormula.ToUpper())
            {
                case "LITROS":
                    CostoUnitario = CostoTotal / Cantidad;
                    break;
                case "MILILITROS":
                    CostoUnitario = (1000 * CostoTotal) / Cantidad;
                    break;
                case "KILOGRAMOS":
                    CostoUnitario = CostoTotal / Cantidad;
                    break;
                case "GRAMOS":
                    CostoUnitario = (1000 * CostoTotal) / Cantidad;
                    break;
                case "MILIGRAMOS":
                    CostoUnitario = (10000 * CostoTotal) / Cantidad;
                    break;
            }
            return CostoUnitario;
            #endregion
        }
        double CalculaPrecioDetalleFormula(string UnidadMedida, double Cantidad, int IdMoneda)
        {
            double PrecioInsumo = 0.0;
            if (IdMoneda == 2)
            {
                PrecioInsumo = Convert.ToDouble(this.PrecioInsumo) * dolar;
            }
            else
            {
                PrecioInsumo = Convert.ToDouble(this.PrecioInsumo);
            }
            double CostoUnitario = 0;
            switch (UnidadMedida.ToUpper())
            {
                case "LITROS":
                    CostoUnitario = Convert.ToDouble(PrecioInsumo) * Cantidad;
                    break;
                case "MILILITROS":
                    CostoUnitario = (1000 / Convert.ToDouble(PrecioInsumo)) * Cantidad;
                    break;
                case "KILOGRAMOS":
                    CostoUnitario = Convert.ToDouble(PrecioInsumo) * Cantidad;
                    break;
                case "GRAMOS":
                    CostoUnitario = (1000 / Convert.ToDouble(PrecioInsumo)) * Cantidad;
                    break;
                case "MILIGRAMOS":
                    CostoUnitario = (10000 / Convert.ToDouble(PrecioInsumo)) * Cantidad;
                    break;
            }
            return CostoUnitario;
        }
        FormulasModel AsignaRowObjetoFormula(DataRow Formula)
        {
            return new FormulasModel
            {
                IdFormula = Convert.ToInt32(Formula["IdFormula"]),
                NombreFormula = Convert.ToString(Formula["NombreFormula"]),
                Cantidad = Convert.ToDouble(Formula["Cantidad"]),
                Capacidad = Convert.ToString(Formula["Capacidad"]),
                UnidadMedida = Convert.ToString(Formula["UnidadMedida"]),
                IdFamilia = Convert.ToInt32(Formula["IdFamilia"]),
            };
        }
        DetallesFormulasModel AsignaRowObjetoDetalleFormula(DataRow DetalleFormula)
        {
            return new DetallesFormulasModel
            {
                IdDetalle = Convert.ToInt32(DetalleFormula["IdDetalle"]),
                IdFormula = Convert.ToInt32(DetalleFormula["IdFormula"]),
                IdInsumo = Convert.ToInt32(DetalleFormula["IdInsumo"]),
                CantidadInsumo = Convert.ToDecimal(DetalleFormula["CantidadInsumo"]),
                UnidadMedidaInsumo = Convert.ToString(DetalleFormula["UnidadMedidaInsumo"]),
                CostoInsumo = Convert.ToDecimal(DetalleFormula["CostoInsumo"]),
            };
        }

        //void ActualizaPrecioInsumo(DataTable Insumo, decimal PrecioInsumo)
        //{
        //    new CNInsumos().Actualizar(new InsumosModel
        //    {
        //        IdInsumo = Convert.ToInt32(Insumo.Rows[0]["IdInsumo"]),
        //        NombreInsumo = Convert.ToString(Insumo.Rows[0]["NombreInsumo"]),
        //        NombreInterno = Convert.ToString(Insumo.Rows[0]["NombreInterno"]),
        //        IdProveedor = Convert.ToInt32(Insumo.Rows[0]["IdProveedor"]),
        //        UnidadMedida = Convert.ToString(Insumo.Rows[0]["UnidadMedida"]),
        //        PrecioUnitario = Convert.ToDouble(PrecioInsumo),
        //        IdFamilia = Convert.ToInt32(Insumo.Rows[0]["IdFamilia"]),
        //        IdMoneda = Convert.ToInt32(Insumo.Rows[0]["IdMoneda"]),
        //    });
        //}
        int CrearFormulaNueva(List<int> listaFormulas)
        {
            int IdFormula = 0;
            for (int i = 0; i < listaFormulas.Count; i++)
            {
                CNFormulas Formulas = new CNFormulas();
                DataTable BusquedaFormulas = Formulas.ConsultaPorId(listaFormulas[i]);
                DataTable DetalleFormula = Detalle.ConsultaPorFormula(listaFormulas[i]);

                IdFormula = 0;//Convert.ToInt32(Formulas.Guardar(AsignaRowObjetoFormula(BusquedaFormulas.Rows[0])));
                Formula.Borrar(listaFormulas[i]);
                foreach (DataRow row in DetalleFormula.Rows)
                {
                    Detalle.Borrar(Convert.ToInt32(row["IdDetalle"]));
                    row["IdFormula"] = IdFormula;
                    if (IdInsumo == Convert.ToInt32(row["IdInsumo"]))
                        row["CostoInsumo"] = CalculaPrecioDetalleFormula(Convert.ToString(row["UnidadMedidaInsumo"]), Convert.ToDouble(row["CantidadInsumo"]), Convert.ToInt32(row["IdMoneda"]));
                    Detalle.Guardar(AsignaRowObjetoDetalleFormula(row));
                }
            }
            return IdFormula;
        }
        void CrearNuevoPrducto(List<int> lista, int IdFormula)//Este método crea un nuevo producto si se creo una nueva formula
        {
            for (int i = 0; i < lista.Count; i++)
            {
                DataTable listaProductos = Producto.ConsultaPorFormula(lista[i]);
                for (int j = 0; j < listaProductos.Rows.Count; j++)
                {
                    DataTable DetallesProductos = DEtalleP.ConsultaDetallesPorProducto(Convert.ToInt32(listaProductos.Rows[j]["IdProducto"]));
                    Producto.Borrar(Convert.ToInt32(listaProductos.Rows[j]["IdProducto"]));

                    ProductosModel _Productos = new ProductosModel
                    {
                        IdProducto = Convert.ToInt32(listaProductos.Rows[j]["IdProducto"]),
                        IdFormula = IdFormula,
                        NombreProducto = Convert.ToString(listaProductos.Rows[j]["NombreProducto"]),
                        Cantidad = Convert.ToDecimal(listaProductos.Rows[j]["Cantidad"]),
                        UnidadMedida = Convert.ToString(listaProductos.Rows[j]["UnidadMedida"]),
                        CostoUnitario = Convert.ToDecimal(CalculaPrecioUnitarioProducto(IdFormula, Convert.ToInt32(listaProductos.Rows[j]["IdProducto"]))),
                        Activo = (bool)(listaProductos.Rows[j]["Activo"]),
                    };
                    _Productos.CostoTotalProducto = _Productos.CostoUnitario + Convert.ToDecimal(PrecioDetalles);

                    int id = Convert.ToInt32(Producto.Guardar(_Productos));
                    foreach (DataRow row in DetallesProductos.Rows)
                    {

                        DEtalleP.Guardar(new DetallesProductosModel
                        {
                            IdDetalle = 0,
                            IdProducto = id,
                            IdInsumo = Convert.ToInt32(row["IdInsumo"]),
                            CostoInsumo = Convert.ToDecimal(row["Precio"])
                        });
                    }

                }

            }
        }
        void CreaProducto(List<int> lista) //Este metodo crea un nuevo producto si se va a modificar su lista de detalles, y ademas recupera el id del nuevo producto
        {
            for (int i = 0; i < lista.Count; i++)
            {
                DataTable listaProductos = Producto.ConsultaConsultaPorId(lista[i]);
                ProductosModel _Productos = new ProductosModel
                {
                    IdProducto = Convert.ToInt32(listaProductos.Rows[0]["IdProducto"]),
                    IdFormula = Convert.ToInt32(listaProductos.Rows[0]["IdFormula"]),
                    NombreProducto = Convert.ToString(listaProductos.Rows[0]["NombreProducto"]),
                    Cantidad = Convert.ToDecimal(listaProductos.Rows[0]["Cantidad"]),
                    UnidadMedida = Convert.ToString(listaProductos.Rows[0]["UnidadMedida"]),
                    CostoUnitario = Convert.ToDecimal(listaProductos.Rows[0]["CostoUnitario"]),
                    CostoTotalProducto = Convert.ToDecimal(listaProductos.Rows[0]["CostoUnitario"]),
                    Activo = (bool)(listaProductos.Rows[0]["Activo"])
                };
                int IdP = Convert.ToInt32(Producto.Guardar(_Productos));
                DataTable Detalles = DEtalleP.ConsultaDetallesPorProducto(Convert.ToInt32(listaProductos.Rows[0]["IdProducto"]));
                double Precio = 0.00;
                foreach (DataRow row in Detalles.Rows)
                {
                    if (Convert.ToInt32(row["IdInsumo"]) == IdInsumo)
                    {
                        row["IdProducto"] = IdP;
                        row["Precio"] = PrecioInsumo;
                        Precio += Convert.ToDouble(row["Precio"]);
                    }
                    else
                    {
                        row["IdProducto"] = IdP;
                        Precio += Convert.ToDouble(row["Precio"]);
                    }

                    DEtalleP.Guardar(new DetallesProductosModel
                    {
                        CostoInsumo = Convert.ToDecimal(row["Precio"]),
                        IdDetalle = Convert.ToInt32(row["IdDetalle"]),
                        IdProducto = Convert.ToInt32(row["IdProducto"]),
                        IdInsumo = IdInsumo,
                    });
                }
                _Productos.IdProducto = IdP;
                _Productos.CostoTotalProducto += Convert.ToDecimal(Precio);
                Producto.Actualizar(_Productos);
                Producto.Borrar(lista[i]);
            }
        }

        public void inputUpdater(int IdInsumo, decimal PrecioInsumo, double dolar)
        {
            listaFormulas.Clear();
            this.dolar = dolar;
            this.IdInsumo = IdInsumo;
            this.PrecioInsumo = PrecioInsumo;
            DataTable BusquedaInsumo = new CNInsumos().ConsultaPorId(IdInsumo);

            //ActualizaPrecioInsumo(BusquedaInsumo, PrecioInsumo);
            DataTable BusquedaFormulas = Detalle.ConsultaPorInsumo(IdInsumo);
            if (BusquedaFormulas.Rows.Count != 0)
            {//SI ENTRA, ES PORQUE EL INSUMO ES UN REACTIVO
                foreach (DataRow row in BusquedaFormulas.Rows)
                {
                    if (!listaFormulas.Contains(Convert.ToInt32(row["IdFormula"])))
                        listaFormulas.Add(Convert.ToInt32(row["IdFormula"]));
                }
                int Id = CrearFormulaNueva(listaFormulas);
                CrearNuevoPrducto(listaFormulas, Id);
                DataRow Formulanueva = Formula.ConsultaPorId(Id).Rows[0];
                BusquedaInsumo = new CNInsumos().ConsultaPorNombre(Formulanueva["NombreFormula"].ToString());
                if (BusquedaInsumo.Rows.Count != 0)
                {
                    for (int i = 0; i < BusquedaInsumo.Rows.Count; i++)
                    {
                        inputUpdater(Convert.ToInt32(BusquedaInsumo.Rows[i]["IdInsumo"]), Convert.ToDecimal(CalculaPrecioUnitarioFormula(Id)), dolar);
                    }
                }
            }
            else
            {//SE VA POR ESTE LADO SI Y SOLO SI EL INSUMO ES DE EMPAQUETADO
                DataTable Productos = DEtalleP.ConsultaDetallesPorInsumo(IdInsumo);
                if (Productos.Rows.Count != 0)
                {
                    foreach (DataRow row in Productos.Rows)
                    {
                        if (!listaProductos.Contains(Convert.ToInt32(row["IdProducto"])))
                        {
                            listaProductos.Add(Convert.ToInt32(row["IdProducto"]));
                        }
                    }
                    CreaProducto(listaProductos);
                }
            }


        }



    }
}
