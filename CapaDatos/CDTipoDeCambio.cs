using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CDTipoDeCambio
    {
        public int Guardar(TipoDeCambioModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spTipoDeCambioGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTipoCambio", SqlDbType.Int).Value = Objeto.IdTipoCambio;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = Objeto.IdMoneda;
                        cmd.Parameters.Add("@FactorConversion", SqlDbType.Decimal).Value = Objeto.FactorConversion;
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
        public int Actualizar(TipoDeCambioModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spTipoDeCambioGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdTipoCambio", SqlDbType.Int).Value = Objeto.IdTipoCambio;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = Objeto.IdMoneda;
                        cmd.Parameters.Add("@FactorConversion", SqlDbType.Decimal).Value = Objeto.FactorConversion;
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
        public DataTable ConsultaGridPorMoneda(int IdMoneda)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spTipoDeCambioConsultaPorMoneda", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = IdMoneda;


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
        public DataTable ConsultaGridReciente()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spTipoCambioConsultaReciente", con))
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
