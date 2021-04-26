using CapaDatos;
using CapaDatos.EntityFramework;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;

namespace CapaNegocios
{
    public class CNInsumos
    {
        private readonly CDInsumos cdInsumos;
        private readonly CDFormulas cdFormulas;
        private readonly CDDetallesFormula cdDetFormula;
        private readonly CDDetallesProductos cdDetProducto;
        private readonly CDProductos cdProductos;

        public int IdUsuario { get; set; }
        public InsumosModel Parametro { get; set; }
        public bool ActualizarPrecios { get; set; }
        public bool EstadoOperacion { get; set; }
        public string Msj { get; set; }
        public decimal PrecioDolar { get; set; }

        public CNInsumos(string conexion, int idUsuario, InsumosModel parametro, bool actualizarPrecios, decimal precioDolar)
        {
            cdInsumos = new CDInsumos(conexion);
            cdFormulas = new CDFormulas(conexion);
            cdDetFormula = new CDDetallesFormula(conexion);
            cdDetProducto = new CDDetallesProductos(conexion);
            cdProductos = new CDProductos(conexion);
            IdUsuario = idUsuario;
            Parametro = parametro;
            ActualizarPrecios = actualizarPrecios;
            PrecioDolar = precioDolar;
        }
        public int Guardar(InsumosModel Objeto)
        {
            int res;
            try
            {
                res = cdInsumos.Guardar(Objeto);
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
        public bool Actualizar(int IdUsuario, InsumosModel Parametro, bool ActualizarPrecios, out string Msj, decimal PrecioDolar = 1)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (cdInsumos.Actualizar(Parametro) < 1)
                        throw new Exception("No se han podido actualizar los datos del insumo.");
                    if (ActualizarPrecios)
                    {
                        int IdFormula = 0;
                        foreach (DataRow item in cdDetFormula.ConsultaGridPorInsumo(Parametro.IdInsumo).Rows)
                            if (Convert.ToInt32(item["IdFormula"]) != IdFormula)
                            {
                                IdFormula = Convert.ToInt32(item["IdFormula"]);
                                DataTable Formula = cdFormulas.ConsultaGridIndividual(IdFormula);
                                DataTable DetallesFormula = cdDetFormula.ConsultaGridPorFormula(IdFormula);
                                decimal CostoTotal = 0;

                                FormulasModel NewFormula = new FormulasModel
                                {
                                    Cantidad = Convert.ToDouble(Formula.Rows[0]["Cantidad"]),
                                    Capacidad = Formula.Rows[0]["Capacidad"].ToString(),
                                    IdFamilia = Convert.ToInt32(Formula.Rows[0]["IdFamilia"]),
                                    NombreFormula = Formula.Rows[0]["NombreFormula"].ToString(),
                                    UnidadMedida = Formula.Rows[0]["UnidadMedida"].ToString()
                                };
                                NewFormula.IdFormula = cdFormulas.Guardar(NewFormula);
                                if (NewFormula.IdFormula < 1)
                                    throw new Exception("No se han podido actualizar el costo de " + item["NombreFormula"].ToString() + ".\n Todos los cambios serán deshechos." +
                                        "Contacte al administrador del sistema.");
                                foreach (DataRow detalle in DetallesFormula.Rows)
                                {
                                    decimal CostoInsumo = Convert.ToInt32(detalle["IdInsumo"]) != Parametro.IdInsumo ? Convert.ToDecimal(detalle["CostoInsumo"]) :
                                        ((Convert.ToDecimal(Parametro.PrecioUnitario) * PrecioDolar) * (Convert.ToDecimal(detalle["CantidadInsumo"]) * FactorMedida(detalle["UnidadMedida"].ToString(), detalle["UnidadMedidaInsumo"].ToString())));
                                    CostoTotal += CostoInsumo;
                                    if (cdDetFormula.Guardar(new DetallesFormulasModel
                                    {
                                        IdFormula = NewFormula.IdFormula,
                                        IdInsumo = Convert.ToInt32(detalle["IdInsumo"]),
                                        CantidadInsumo = Convert.ToDecimal(detalle["CantidadInsumo"]),
                                        UnidadMedidaInsumo = detalle["UnidadMedidaInsumo"].ToString(),
                                        CostoInsumo = CostoInsumo,
                                        IdUsuario = IdUsuario
                                    }) < 1)
                                        throw new Exception("No se han podido actualizar el costo en los detalles de " + item["NombreFormula"].ToString() + ".\n Todos los cambios serán deshechos." +
                                         "Contacte al administrador del sistema.");
                                }
                                //calculo el costo de generar la unidad mas pequeña de la formula
                                //por ejemplo, si son kg, cuanto cuesta  crear un mg?
                                // si son Litros, cuanto cuesta crear un ml?

                                decimal CostoMinimoFormula = NewFormula.UnidadMedida.ToString().Equals("K") ?
                                                         (Convert.ToDecimal(CostoTotal) / (NewFormula.Capacidad.ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(NewFormula.Cantidad)) :
                                                                                                      NewFormula.Capacidad.ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(NewFormula.Cantidad)) :
                                                                                                      Convert.ToDecimal(NewFormula.Cantidad))) :
                                                         (Convert.ToDecimal(CostoTotal) / (NewFormula.Capacidad.ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(NewFormula.Cantidad)) :
                                                                                                      Convert.ToDecimal(NewFormula.Cantidad)));

                                foreach (DataRow Producto in cdProductos.ConsultaGridPorFormula(IdFormula).Rows)
                                {
                                    decimal CostoGranel = CostoMinimoFormula *
                                      (Producto["UnidadMedida"].ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(Producto["Cantidad"])) :
                                     Producto["UnidadMedida"].ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(Producto["Cantidad"])) :
                                     Producto["UnidadMedida"].ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(Producto["Cantidad"])) :
                                      Convert.ToDecimal(Producto["Cantidad"]));


                                    List<DetallesProductosModel> detalles = new List<DetallesProductosModel>();
                                    foreach (DataRow detProducto in cdDetProducto.ConsultaGridPorProducto(Convert.ToInt32(Producto["IdProducto"])).Rows)
                                        detalles.Add(new DetallesProductosModel
                                        {
                                            CostoInsumo = Convert.ToDecimal(detProducto["Precio"]),
                                            IdInsumo = Convert.ToInt32(detProducto["IdInsumo"])
                                        });
                                    ProductosModel newProducto = new ProductosModel
                                    {
                                        IdProducto = Convert.ToInt32(Producto["IdProducto"]),
                                        IdFormula = NewFormula.IdFormula,
                                        NombreProducto = Producto["NombreProducto"].ToString(),
                                        Cantidad = Convert.ToDecimal(Producto["Cantidad"]),
                                        UnidadMedida = Producto["UnidadMedida"].ToString(),
                                        CostoUnitario = CostoGranel,
                                        CostoTotalProducto = detalles.Sum(x => x.CostoInsumo) + CostoGranel,
                                        Activo = true,
                                        IdUsuario = IdUsuario
                                    };
                                    newProducto.IdProducto = cdProductos.Actualizar(newProducto);
                                    //detalles.ForEach(x => x.IdProducto = newProducto.IdProducto);
                                    detalles.ForEach(x => cdDetProducto.Actualizar(x));


                                }
                                //cdProductos.BorrarPorFormula(IdFormula);
                                if (cdFormulas.Borrar(IdFormula) < 1)
                                    throw new Exception("No se han podido dar de baja " + item["NombreFormula"].ToString() + ".\n Todos los cambios serán deshechos." +
                                                                           "Contacte al administrador del sistema.");

                                foreach (DataRow itemInsumo in cdInsumos.ConsultaGridPorNombre(item["NombreFormula"].ToString()).Rows)
                                {
                                    Actualizar(IdUsuario, new InsumosModel
                                    {
                                        IdInsumo = Convert.ToInt32(itemInsumo["IdInsumo"]),
                                        IdProveedor = Convert.ToInt32(itemInsumo["IdProveedor"]),
                                        NombreInsumo = itemInsumo["NombreInsumo"].ToString(),
                                        NombreInterno = itemInsumo["NombreInterno"].ToString(),
                                        UnidadMedida = itemInsumo["UnidadMedida"].ToString(),
                                        PrecioUnitario = Convert.ToDouble(CostoMinimoFormula *
                                                      (itemInsumo["UnidadMedida"].ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(NewFormula.Cantidad)) :
                                                     itemInsumo["UnidadMedida"].ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(NewFormula.Cantidad)) :
                                                     itemInsumo["UnidadMedida"].ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(NewFormula.Cantidad)) :
                                                      Convert.ToDecimal(1))),
                                        TotalCompraMX = 10000,
                                        IdFamilia = Convert.ToInt32(itemInsumo["IdFamilia"]),
                                        IdMoneda = Convert.ToInt32(itemInsumo["IdMoneda"]),

                                    }, true, out string MsjI, PrecioDolar);
                                }

                            }

                        int IdProducto = 0;
                        foreach (DataRow itemDetalle in cdDetProducto.ConsultaGridPorInsumo(Parametro.IdInsumo).Rows)
                        {
                            if (Convert.ToInt32(itemDetalle["IdProducto"]) != IdProducto)
                            {
                                IdProducto = Convert.ToInt32(itemDetalle["IdProducto"]);
                                DataTable Producto = cdProductos.ConsultaGridPorId(IdProducto);
                                if ((bool)(Producto.Rows[0]["Activo"]))
                                {
                                    List<DetallesProductosModel> detalles = new List<DetallesProductosModel>();
                                    foreach (DataRow detProducto in cdDetProducto.ConsultaGridPorProducto(IdProducto).Rows)
                                    {
                                        decimal CostoInsumo = Convert.ToInt32(detProducto["IdInsumo"]) != Parametro.IdInsumo ? Convert.ToDecimal(detProducto["Precio"]) :
                                            (Convert.ToDecimal(Parametro.PrecioUnitario) * PrecioDolar);
                                        detalles.Add(new DetallesProductosModel
                                        {
                                            CostoInsumo = CostoInsumo,
                                            IdDetalle = Convert.ToInt32(detProducto["IdDetalle"]),
                                            IdInsumo = Convert.ToInt32(detProducto["IdInsumo"])
                                        });
                                    }
                                    ProductosModel newProducto = new ProductosModel
                                    {
                                        IdProducto = Convert.ToInt32(Producto.Rows[0]["IdProducto"]),
                                        IdFormula = Convert.ToInt32(Producto.Rows[0]["IdFormula"]),
                                        NombreProducto = Producto.Rows[0]["NombreProducto"].ToString(),
                                        Cantidad = Convert.ToDecimal(Producto.Rows[0]["Cantidad"]),
                                        UnidadMedida = Producto.Rows[0]["UnidadMedida"].ToString(),
                                        CostoUnitario = Convert.ToDecimal(Producto.Rows[0]["CostoUnitario"]),
                                        CostoTotalProducto = detalles.Sum(x => x.CostoInsumo) + Convert.ToDecimal(Producto.Rows[0]["CostoUnitario"]),
                                        Activo = true,
                                        IdUsuario = IdUsuario
                                    };
                                    newProducto.IdProducto = cdProductos.Actualizar(newProducto);
                                    //detalles.ForEach(x => x.IdProducto = newProducto.IdProducto);
                                    detalles.ForEach(x => cdDetProducto.Actualizar(x));
                                    //if (cdProductos.BorrarPorId(IdProducto) < 1)
                                    //    throw new Exception("No se ha podido dar de baja " + newProducto.NombreProducto + ".\n Todos los cambios serán deshechos." +
                                    //                                           "Contacte al administrador del sistema.");
                                }
                            }
                        }
                    }
                    scope.Complete();
                }
                Msj = "";
                return true;
            }
            catch (Exception er)
            {
                Msj = (er.Message);
                return false;
            }
        }
        public void ActualizarP()
        {
            try
            {
                //Thread.Sleep(2000);

                using (TransactionScope scope = new TransactionScope())
                {
                    #region
                    if (cdInsumos.Actualizar(Parametro) < 1)
                        throw new Exception("No se han podido actualizar los datos del insumo.");

                    if (ActualizarPrecios)
                    {
                        int IdFormula = 0;
                        foreach (DataRow item in cdDetFormula.ConsultaGridPorInsumo(Parametro.IdInsumo).Rows)
                            if (Convert.ToInt32(item["IdFormula"]) != IdFormula)
                            {
                                IdFormula = Convert.ToInt32(item["IdFormula"]);
                                cdDetFormula.Actualizar(new DetallesFormulasModel
                                {
                                    IdDetalle = Convert.ToInt32(item[0]),
                                    IdFormula = Convert.ToInt32(item[1]),
                                    IdInsumo = Parametro.IdInsumo,
                                    CantidadInsumo = Convert.ToInt32(item["CantidadInsumo"]),
                                    UnidadMedidaInsumo = item["UnidadMedidaInsumo"].ToString(),
                                    CostoInsumo = ((Convert.ToDecimal(Parametro.PrecioUnitario) * PrecioDolar) * (Convert.ToDecimal(item["CantidadInsumo"]) *
                                    FactorMedida(item["UnidadMedida"].ToString(), item["UnidadMedidaInsumo"].ToString()))),
                                    IdUsuario = Parametro.IdUsuario
                                });

                                DataTable tblFormula = cdFormulas.ConsultaGridIndividual(IdFormula);

                                FormulasModel formula = new FormulasModel
                                {
                                    Cantidad = Convert.ToDouble(tblFormula.Rows[0]["Cantidad"]),
                                    Capacidad = tblFormula.Rows[0]["Capacidad"].ToString(),
                                    IdFamilia = Convert.ToInt32(tblFormula.Rows[0]["IdFamilia"]),
                                    NombreFormula = tblFormula.Rows[0]["NombreFormula"].ToString(),
                                    UnidadMedida = tblFormula.Rows[0]["UnidadMedida"].ToString(),
                                    CostoTotal = Convert.ToDecimal(tblFormula.Rows[0]["CostoTotal"]),
                                    IdFormula = Convert.ToInt32(tblFormula.Rows[0]["IdFormula"]),
                                };

                                //calculo el costo de generar la unidad mas pequeña de la formula
                                //por ejemplo, si son kg, cuanto cuesta  crear un mg?
                                // si son Litros, cuanto cuesta crear un ml?
                                decimal CostoMinimoFormula = formula.UnidadMedida.ToString().Equals("K") ?
                                                         (Convert.ToDecimal(formula.CostoTotal) / (formula.Capacidad.ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(formula.Cantidad)) :
                                                                                                      formula.Capacidad.ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(formula.Cantidad)) :
                                                                                                      Convert.ToDecimal(formula.Cantidad))) :
                                                         (Convert.ToDecimal(formula.CostoTotal) / (formula.Capacidad.ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(formula.Cantidad)) :
                                                                                                      Convert.ToDecimal(formula.Cantidad)));

                                foreach (DataRow Producto in cdProductos.ConsultaGridPorFormula(IdFormula).Rows)
                                {
                                    decimal CostoGranel = CostoMinimoFormula *
                                      (Producto["UnidadMedida"].ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(Producto["Cantidad"])) :
                                     Producto["UnidadMedida"].ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(Producto["Cantidad"])) :
                                     Producto["UnidadMedida"].ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(Producto["Cantidad"])) :
                                      Convert.ToDecimal(Producto["Cantidad"]));


                                    List<DetallesProductosModel> detalles = new List<DetallesProductosModel>();
                                    foreach (DataRow detProducto in cdDetProducto.ConsultaGridPorProducto(Convert.ToInt32(Producto["IdProducto"])).Rows)
                                        detalles.Add(new DetallesProductosModel
                                        {
                                            CostoInsumo = Convert.ToDecimal(detProducto["Precio"]),
                                            IdInsumo = Convert.ToInt32(detProducto["IdInsumo"])
                                        });
                                    ProductosModel newProducto = new ProductosModel
                                    {
                                        IdProducto = Convert.ToInt32(Producto["IdProducto"]),
                                        IdFormula = formula.IdFormula,
                                        NombreProducto = Producto["NombreProducto"].ToString(),
                                        Cantidad = Convert.ToDecimal(Producto["Cantidad"]),
                                        UnidadMedida = Producto["UnidadMedida"].ToString(),
                                        CostoUnitario = CostoGranel,
                                        CostoTotalProducto = detalles.Sum(x => x.CostoInsumo) + CostoGranel,
                                        Activo = true,
                                        IdUsuario = IdUsuario
                                    };
                                    newProducto.IdProducto = cdProductos.Actualizar(newProducto);


                                }                              

                                foreach (DataRow itemInsumo in cdInsumos.ConsultaGridPorNombre(item["NombreFormula"].ToString()).Rows)
                                {
                                    Actualizar(IdUsuario, new InsumosModel
                                    {
                                        IdInsumo = Convert.ToInt32(itemInsumo["IdInsumo"]),
                                        IdProveedor = Convert.ToInt32(itemInsumo["IdProveedor"]),
                                        NombreInsumo = itemInsumo["NombreInsumo"].ToString(),
                                        NombreInterno = itemInsumo["NombreInterno"].ToString(),
                                        UnidadMedida = itemInsumo["UnidadMedida"].ToString(),
                                        PrecioUnitario = Convert.ToDouble(CostoMinimoFormula *
                                                      (itemInsumo["UnidadMedida"].ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(formula.Cantidad)) :
                                                     itemInsumo["UnidadMedida"].ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(formula.Cantidad)) :
                                                     itemInsumo["UnidadMedida"].ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(formula.Cantidad)) :
                                                      Convert.ToDecimal(1))),
                                        TotalCompraMX = 10000,
                                        IdFamilia = Convert.ToInt32(itemInsumo["IdFamilia"]),
                                        IdMoneda = Convert.ToInt32(itemInsumo["IdMoneda"]),

                                    }, true, out string MsjI, PrecioDolar);
                                }

                            }

                        int IdProducto = 0;
                        foreach (DataRow itemDetalle in cdDetProducto.ConsultaGridPorInsumo(Parametro.IdInsumo).Rows)
                        {
                            if (Convert.ToInt32(itemDetalle["IdProducto"]) != IdProducto)
                            {
                                IdProducto = Convert.ToInt32(itemDetalle["IdProducto"]);
                                DataTable Producto = cdProductos.ConsultaGridPorId(IdProducto);
                                if ((bool)(Producto.Rows[0]["Activo"]))
                                {
                                    List<DetallesProductosModel> detalles = new List<DetallesProductosModel>();
                                    foreach (DataRow detProducto in cdDetProducto.ConsultaGridPorProducto(IdProducto).Rows)
                                    {
                                        decimal CostoInsumo = Convert.ToInt32(detProducto["IdInsumo"]) != Parametro.IdInsumo ? Convert.ToDecimal(detProducto["Precio"]) :
                                            (Convert.ToDecimal(Parametro.PrecioUnitario) * PrecioDolar);
                                        detalles.Add(new DetallesProductosModel
                                        {
                                            CostoInsumo = CostoInsumo,
                                            IdDetalle = Convert.ToInt32(detProducto["IdDetalle"]),
                                            IdInsumo = Convert.ToInt32(detProducto["IdInsumo"])
                                        });
                                    }
                                    ProductosModel newProducto = new ProductosModel
                                    {
                                        IdProducto = Convert.ToInt32(Producto.Rows[0]["IdProducto"]),
                                        IdFormula = Convert.ToInt32(Producto.Rows[0]["IdFormula"]),
                                        NombreProducto = Producto.Rows[0]["NombreProducto"].ToString(),
                                        Cantidad = Convert.ToDecimal(Producto.Rows[0]["Cantidad"]),
                                        UnidadMedida = Producto.Rows[0]["UnidadMedida"].ToString(),
                                        CostoUnitario = Convert.ToDecimal(Producto.Rows[0]["CostoUnitario"]),
                                        CostoTotalProducto = detalles.Sum(x => x.CostoInsumo) + Convert.ToDecimal(Producto.Rows[0]["CostoUnitario"]),
                                        Activo = true,
                                        IdUsuario = IdUsuario
                                    };
                                    newProducto.IdProducto = cdProductos.Actualizar(newProducto);
                                    detalles.ForEach(x => cdDetProducto.Actualizar(x));
                                }
                            }
                        }
                    }
                    #endregion
                    scope.Complete();
                }
                Msj = "";
                EstadoOperacion = true;

            }
            catch (Exception er)
            {
                Msj = (er.Message);
                EstadoOperacion = false;
                //return false;
            }
        }
        private decimal FactorMedida(string UnidadMedida, string UnidadMedidaInsumo)
        {
            switch (UnidadMedida.ToUpper())
            {
                case "KG":
                    switch (UnidadMedidaInsumo.ToUpper())
                    {
                        case "KILOGRÁMOS":
                            return 1;
                        case "GRÁMOS":
                            return 1.00m / 1000.00m;
                        case "MILIGRÁMOS":
                            return 1.00m / 1000000.00m;
                    }
                    break;
                case "L":
                    switch (UnidadMedidaInsumo.ToUpper())
                    {
                        case "LITROS":
                            return 1;
                        case "MILILITROS":
                            return 1.00m / 1000.00m;
                    }
                    break;
                default:
                    return 1;
            }
            return 1;
        }

        public DataTable ConsultaGeneral()
        {
            try
            {
                return cdInsumos.ConsultaGridGeneral();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorId(int Id)
        {
            try
            {
                return cdInsumos.ConsultaGridPorId(Id);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorProveedor(int IdProveedor)
        {
            try
            {
                return cdInsumos.ConsultaGridPorProveedor(IdProveedor);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorFamilia(int IdFamilia)
        {
            try
            {
                return cdInsumos.ConsultaGridPorFamilia(IdFamilia);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorNombre(string Nombre)
        {
            try
            {
                return cdInsumos.ConsultaGridPorNombre(Nombre);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaInsumosIngredientes()
        {
            try
            {
                return cdInsumos.ConsultaGridIngredientes();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaInsumosDeEmpacado()
        {
            try
            {
                return cdInsumos.ConsultaGridAcabados();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorMoneda(int IdMoneda)
        {
            try
            {
                return cdInsumos.ConsultaGridPorMoneda(IdMoneda);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

        public int Borrar(int IdInsumo)
        {
            try
            {
                return cdInsumos.Borrar(IdInsumo);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
