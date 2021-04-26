using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDFamiliaFormulas
    {
        private string conexion { get; set; }

        public CDFamiliaFormulas(string conexion)
        {
            this.conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        }

        public int Guardar(FamiliaFormulasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFamiliasFormulasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = Objeto.IdFamilia;
                        cmd.Parameters.Add("@NombreFamilia", SqlDbType.NVarChar).Value = Objeto.nombreFamilia;
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
        public int Actualizar(FamiliaFormulasModel Objeto)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFamiliasFormulasGuardar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = Objeto.IdFamilia;
                        cmd.Parameters.Add("@NombreFamilia", SqlDbType.NVarChar).Value = Objeto.nombreFamilia;
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
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFamiliaFormulasConsultaGeneral", con))
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

        public DataTable ConsultaGridIndividual(int IdFamilia)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFamiliaFormulasConsultaIndividual", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = IdFamilia;


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
        public int Borrar(int IdFamilia)
        {
            int res;
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("spFamiliaFormulasBorrar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = IdFamilia;
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
