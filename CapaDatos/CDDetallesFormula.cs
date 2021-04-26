using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CDDetallesFormula
    {
        private string conexion { get; set; }

        public CDDetallesFormula(string conexion)
        {
            this.conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public int Guardar(DetallesFormulasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesFormulasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Objeto.IdDetalle;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = Objeto.IdFormula;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        cmd.Parameters.Add("@CantidadInsumo", SqlDbType.Decimal).Value = Objeto.CantidadInsumo;
                        cmd.Parameters.Add("@UnidadMedidaInsumo", SqlDbType.NVarChar).Value = Objeto.UnidadMedidaInsumo;
                        cmd.Parameters.Add("@CostoInsumo", SqlDbType.Decimal).Value = Objeto.CostoInsumo;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Objeto.IdUsuario;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.NVarChar).Value = "G";
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
        public int Actualizar(DetallesFormulasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesFormulasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Objeto.IdDetalle;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = Objeto.IdFormula;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = Objeto.IdInsumo;
                        cmd.Parameters.Add("@CantidadInsumo", SqlDbType.Decimal).Value = Objeto.CantidadInsumo;
                        cmd.Parameters.Add("@UnidadMedidaInsumo", SqlDbType.NVarChar).Value = Objeto.UnidadMedidaInsumo;
                        cmd.Parameters.Add("@CostoInsumo", SqlDbType.Decimal).Value = Objeto.CostoInsumo;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Objeto.IdUsuario;
                        cmd.Parameters.Add("@DetalleAccion", SqlDbType.NVarChar).Value = "A";
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
        public int Borrar(int IdDetalle)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesFormulasDaraDeBaja", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = IdDetalle;
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

        public int CambiarPrecios(DetallesFormulasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spCambiarPreciosFormulas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = Objeto.IdDetalle;
                        cmd.Parameters.Add("@IdFormula", SqlDbType.Int).Value = Objeto.IdFormula;
                        cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = Objeto.Precio;
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
        public DataTable ConsultaGridPorFormula(int IdFormula)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesFormulasConsultaPorFormula", con))
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
        public DataTable ConsultaGridPorId(int IdDetalle)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesFormulasConsultaPorId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdDetalle", SqlDbType.Int).Value = IdDetalle;


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
        public DataTable ConsultaGridPorInsumo(int IdInsumo)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesFormulasConsultaPorInsumo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdInsumo", SqlDbType.Int).Value = IdInsumo;


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
        public DataTable ConsultaGridPorMoneda()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spDetallesFormulasConsultaPorMoneda", con))
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
    }
}
