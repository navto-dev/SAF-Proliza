using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDProductos
    {
        private string conexion { get; set; }

        public CDProductos(string conexion)
        {
            this.conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public int Guardar(ProductosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Objeto.IdProducto;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = Objeto.IdFormula;
                        cmd.Parameters.Add("@NombreProducto", SqlDbType.NVarChar).Value = Objeto.NombreProducto;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Objeto.Cantidad;
                        cmd.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = Objeto.UnidadMedida;
                        cmd.Parameters.Add("@CostoUnitario", SqlDbType.VarChar).Value = Objeto.CostoUnitario;
                        cmd.Parameters.Add("@CostoTotalProducto", SqlDbType.VarChar).Value = Objeto.CostoTotalProducto;
                        cmd.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Objeto.Activo;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Objeto.IdUsuario;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.VarChar).Value = "G";
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return res;
        }
        public int Actualizar(ProductosModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = Objeto.IdProducto;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = Objeto.IdFormula;
                        cmd.Parameters.Add("@NombreProducto", SqlDbType.NVarChar).Value = Objeto.NombreProducto;
                        cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Objeto.Cantidad;
                        cmd.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = Objeto.UnidadMedida;
                        cmd.Parameters.Add("@CostoUnitario", SqlDbType.VarChar).Value = Objeto.CostoUnitario;
                        cmd.Parameters.Add("@CostoTotalProducto", SqlDbType.VarChar).Value = Objeto.CostoTotalProducto;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Objeto.IdUsuario;
                        cmd.Parameters.Add("@Activo", SqlDbType.VarChar).Value = Objeto.Activo;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.VarChar).Value = "A";
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return res;
        }

        public DataTable ConsultaGridPorNombre(string Nombre)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosConsultaPorNombre", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@NombreProducto", SqlDbType.NVarChar).Value = Nombre;


                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return tabla;
        }
        public DataTable ConsultaGridPorId(int IdProducto)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosConsultaPorId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = IdProducto;


                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return tabla;
        }
        public DataTable ConsultaGridPorFormula(int IdFormula)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosConsultaPorFormula", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = IdFormula;


                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return tabla;
        }
        public DataTable ConsultaGridActivos()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosConsultaActivos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return tabla;
        }
        public DataTable ConsultaGridCatalogo()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosConsultaCatalogo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return tabla;
        }
        public DataTable ConsultaGridVariedades(int IdFormula, string NombreProducto)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosConsultaVariedades", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = IdFormula;
                        cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = NombreProducto;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            adapter.Fill(tabla);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return tabla;
        }

        public int BorrarPorFormula(int IdFormula)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDarDeBajaProductosPorFormula", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = IdFormula;
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteNonQuery());
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return res;
        }
        public int BorrarPorId(int IdProducto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spProductosTerminadosDarDeBaja", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdProduto", SqlDbType.Int).Value = IdProducto;
                        con.Open();
                        res = Convert.ToInt32(cmd.ExecuteNonQuery());
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return res;
        }

    }
}
