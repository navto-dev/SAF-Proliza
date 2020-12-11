using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDMonedas
    {
        public int Guardar(MonedasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spMonedasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = Objeto.IdMoneda;
                        cmd.Parameters.Add("@NombreMoneda", SqlDbType.NVarChar).Value = Objeto.nombreMoneda;
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
        public int Actualizar(MonedasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spMonedasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = Objeto.IdMoneda;
                        cmd.Parameters.Add("@NombreMoneda", SqlDbType.NVarChar).Value = Objeto.nombreMoneda;
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
        public DataTable ConsultaGridGeneral()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(AConexion.con))
                {
                    using (SqlCommand cmd = new SqlCommand("spMonedasConsultaGeneral", con))
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
