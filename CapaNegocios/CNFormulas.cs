using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;

namespace CapaNegocios
{
    public class CNFormulas
    {

        public int Guardar(int IdUser, FormulasModel Objeto, DataTable DetallesFormula)
        {
            int res;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    res = new CDFormulas().Guardar(Objeto);
                    if (res < 1)
                        throw new Exception("Error al guardar datos generales de la fórmula.");
                    foreach (DataRow item in DetallesFormula.Rows)
                        new CDDetallesFormula().Guardar(new DetallesFormulasModel
                        {
                            IdDetalle = Convert.ToInt32(item["IdDetalle"]),
                            IdFormula = res,
                            IdInsumo = Convert.ToInt32(item["IdInsumo"]),
                            CantidadInsumo = Convert.ToDecimal(item["Cantidad"].ToString().Split(' ')[0]),
                            UnidadMedidaInsumo = item["Cantidad"].ToString().Split(' ')[1],
                            CostoInsumo = Convert.ToDecimal(item["Precio"]),
                            IdUsuario = IdUser
                        });

                    if (Objeto.IdFormula > 0)
                    {
                        foreach (DataRow Producto in new CDProductos().ConsultaGridPorFormula(Objeto.IdFormula).Rows)
                        {
                            decimal CostoMinimoFormula = Objeto.UnidadMedida.ToString().Equals("K") ?
                                                        (Convert.ToDecimal(Objeto.CostoTotal) / (Objeto.Capacidad.ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(Objeto.Cantidad)) :
                                                                                                     Objeto.Capacidad.ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(Objeto.Cantidad)) :
                                                                                                     Convert.ToDecimal(Objeto.Cantidad))) :
                                                        (Convert.ToDecimal(Objeto.CostoTotal) / (Objeto.Capacidad.ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(Objeto.Cantidad)) :
                                                                                                     Convert.ToDecimal(Objeto.Cantidad)));


                            decimal CostoGranel = CostoMinimoFormula *
                              (Producto["UnidadMedida"].ToString().ToUpper().StartsWith("L") ? ConversorUnidades.Litros_Mililitros(Convert.ToDecimal(Producto["Cantidad"])) :
                             Producto["UnidadMedida"].ToString().ToUpper().StartsWith("K") ? ConversorUnidades.Kilos_Miligramos(Convert.ToDecimal(Producto["Cantidad"])) :
                             Producto["UnidadMedida"].ToString().ToUpper().StartsWith("G") ? ConversorUnidades.Gramos_Miligramos(Convert.ToDecimal(Producto["Cantidad"])) :
                              Convert.ToDecimal(Producto["Cantidad"]));


                            List<DetallesProductosModel> detalles = new List<DetallesProductosModel>();
                            foreach (DataRow detProducto in new CDDetallesProductos().ConsultaGridPorProducto(Convert.ToInt32(Producto["IdProducto"])).Rows)
                                detalles.Add(new DetallesProductosModel
                                {
                                    CostoInsumo = Convert.ToDecimal(detProducto["Precio"]),
                                    IdInsumo = Convert.ToInt32(detProducto["IdInsumo"])
                                });
                            ProductosModel newProducto = new ProductosModel
                            {
                                IdFormula = res,
                                NombreProducto = Producto["NombreProducto"].ToString(),
                                Cantidad = Convert.ToDecimal(Producto["Cantidad"]),
                                UnidadMedida = Producto["UnidadMedida"].ToString(),
                                CostoUnitario = CostoGranel,
                                CostoTotalProducto = detalles.Sum(x => x.CostoInsumo) + CostoGranel,
                                Activo = true
                            };
                            newProducto.IdProducto = new CDProductos().Guardar(newProducto);
                            detalles.ForEach(x => x.IdProducto = newProducto.IdProducto);
                            detalles.ForEach(x => new CDDetallesProductos().Guardar(x));


                        }
                        new CDProductos().BorrarPorFormula(Objeto.IdFormula);
                        if (new CDFormulas().Borrar(Objeto.IdFormula) < 1)
                            throw new Exception("No se han podido dar de baja " + Objeto.NombreFormula + ".\n Todos los cambios serán deshechos." +
                                                                   "Contacte al administrador del sistema.");
                    }
                    if (Objeto.IdFamilia == 1)
                    {//Es Insumo
                        DataTable Insumo = new CDInsumos().ConsultaGridPorNombre(Objeto.NombreFormula);
                        if (Insumo.Rows.Count == 0)
                            new CDInsumos().Guardar(new InsumosModel
                            {
                                IdFamilia = 1,
                                IdMoneda = 1,
                                IdProveedor = 1,
                                NombreInsumo = Objeto.NombreFormula,
                                NombreInterno = Objeto.NombreFormula,
                                UnidadMedida = Objeto.UnidadMedida.Equals("L") ? Objeto.UnidadMedida : "KG",
                                PrecioUnitario = CostoFormulaPorUnidad(Convert.ToDouble(Objeto.CostoTotal), Objeto.Cantidad, Objeto.Capacidad),
                                TotalCompraMX = 1000
                            });
                        else
                        {
                            new CNInsumos().Actualizar(IdUser, new InsumosModel
                            {
                                IdInsumo = Convert.ToInt32(Insumo.Rows[0]["IdInsumo"]),
                                IdFamilia = 1,
                                IdMoneda = 1,
                                IdProveedor = 1,
                                NombreInsumo = Objeto.NombreFormula,
                                NombreInterno = Objeto.NombreFormula,
                                UnidadMedida = Objeto.UnidadMedida.Equals("L") ? Objeto.UnidadMedida : "KG",
                                PrecioUnitario = CostoFormulaPorUnidad(Convert.ToDouble(Objeto.CostoTotal), Objeto.Cantidad, Objeto.Capacidad),
                                TotalCompraMX = 1000
                            }, true, out string Msj);
                        }
                    }

                    scope.Complete();
                }
            }
            catch (Exception)
            {
                res = 0;
            }
            return res;
        }
        double CostoFormulaPorUnidad(double CostoTotal, double Cantidad, string Capacidad)
        {
            switch (Capacidad.ToLower())
            {
                case "litros":
                    return CostoTotal / Cantidad;
                case "mililitros":
                    return (CostoTotal / Cantidad) * 1000;

                case "kilográmos":
                    return CostoTotal / Cantidad;
                case "grámos":
                    return (CostoTotal / Cantidad) * 1000;
                case "miligrámos":
                    return (CostoTotal / Cantidad) * 1000000;

            }
            return 0;
        }
        public int Actualizar(FormulasModel Parametro)
        {
            try
            {
                return new CDFormulas().Actualizar(Parametro);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public int Borrar(int IdFormula)
        {
            try
            {
                return new CDFormulas().Borrar(IdFormula);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaGeneral()
        {
            try
            {
                return new CDFormulas().ConsultaGridActivas();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorNombre(string Nombre, bool Activo)
        {
            try
            {
                return new CDFormulas().ConsultaGridPorNombre(Nombre, Activo);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
        public DataTable ConsultaPorId(int IdFormula)
        {
            try
            {
                return new CDFormulas().ConsultaGridIndividual(IdFormula);
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
                return new CDFormulas().ConsultaGridPorFamilia(IdFamilia);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
