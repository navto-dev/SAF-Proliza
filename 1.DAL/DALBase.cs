using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALBase
    {
        SqlCommand SqlCommand1 = new SqlCommand();
        SqlConnection SqlConnection = new SqlConnection();
        SqlDataAdapter SqlDataAdapter1;
        public SqlTransaction SqlTransac;
        int IntTimeOut = 50000;
        bool BlnTransaccion = false;

        #region "propiedades"
        public string CadenaSQL { get; set; }
        public string ConexionString { get; set; }
        public Boolean Transaccion { get; set; }
        #endregion

        #region "Constructores"
        public DALBase(string ConexionString)
        {
            if (string.IsNullOrEmpty(ConexionString))
                throw new Exception("Debe especificar la cadena de conexión");
            else
                this.ConexionString = ConexionString;
        }
        #endregion


        #region "Metodos"

        public SqlParameter AgregarParametro(String Nombre, SqlDbType Tipo, object Valor, string direccion = "I")
        {
            try
            {
                SqlParameter param = SqlCommand1.Parameters.Add(Nombre, Tipo);
                param.Value = Valor;
                param.Direction = direccion == "I" ? ParameterDirection.Input : ParameterDirection.Output;
                return param;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }


        public void InicializaCommand()
        {
            try
            {
                SqlCommand1.CommandText = this.CadenaSQL;
                SqlCommand1.CommandTimeout = IntTimeOut;
                SqlCommand1.Connection = SqlConnection;
                SqlCommand1.Parameters.Clear();
                //Valida si es un stored procedure
                if (!this.CadenaSQL.ToUpper().StartsWith("SELECT ")
                    && !this.CadenaSQL.ToUpper().StartsWith("INSERT ")
                    && !this.CadenaSQL.ToUpper().StartsWith("UPDATE ")
                    && !this.CadenaSQL.ToUpper().StartsWith("DELETE ")
                    && !this.CadenaSQL.ToUpper().StartsWith("CREATE ")
                    && !this.CadenaSQL.ToUpper().StartsWith("DROP "))
                    SqlCommand1.CommandType = CommandType.StoredProcedure;
                else
                    SqlCommand1.CommandType = CommandType.Text;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public void ConectaBD()
        {
            try
            {
                if (!(SqlConnection.State == ConnectionState.Open))
                {
                    SqlConnection.ConnectionString = this.ConexionString;
                    SqlConnection.Open();
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }

        }

        public int EjecutaBD()
        {
            try
            {
                ConectaBD();
                return SqlCommand1.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public DataSet ConsultaCadena(string NombreTabla)
        {
            try
            {
                DataSet DtsRegresa = new DataSet();
                ConectaBD();
                SqlDataAdapter1 = new SqlDataAdapter(SqlCommand1);
                SqlDataAdapter1.Fill(DtsRegresa, NombreTabla);
                return DtsRegresa;
                //SqlDataAdapter1.Dispose();
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public bool IniciaTransaccion()
        {
            try
            {
                Boolean BlnIniciTrn = false;
                if (!BlnTransaccion)
                {
                    ConectaBD();
                    SqlTransac = SqlConnection.BeginTransaction();
                    SqlCommand1.Transaction = SqlTransac;
                    BlnTransaccion = true;
                    BlnIniciTrn = true;
                }
                return BlnIniciTrn;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public void FinalizaTransaccion()
        {
            try
            {
                if (BlnTransaccion)
                {
                    SqlTransac.Commit();
                    BlnTransaccion = false;
                }
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public void CierraConexion()
        {
            try
            {
                if (SqlConnection.State == ConnectionState.Open)
                    SqlConnection.Close();
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public void DescartaTransaccion()
        {
            try
            {
                if (BlnTransaccion)
                {
                    SqlTransac.Rollback();
                    BlnTransaccion = false;
                }
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public String GuardaTabla(DataTable tabla, String prefijo)
        {
            try
            {
                //Clona la tabla
                DataTable dtbGen = tabla.Clone();
                foreach (DataRow myRow in tabla.Rows)
                    dtbGen.Rows.Add(myRow.ItemArray);
                //Genera el nombre de la tabla
                if (tabla.TableName == "") throw new Exception("No se puede crear la tabla debido a que no se especifico un nombre");
                String strNomTabla = prefijo + tabla.TableName;
                String strExe = ComandoCreaTabla(tabla, strNomTabla);
                CadenaSQL = strExe;
                InicializaCommand();
                EjecutaBD();
                //Guarda la informacion del datatable
                strExe = "select * from " + strNomTabla;
                SqlDataAdapter1 = new SqlDataAdapter(strExe, SqlConnection);
                SqlCommandBuilder CmmGen = new SqlCommandBuilder(SqlDataAdapter1);
                SqlDataAdapter1.InsertCommand = CmmGen.GetInsertCommand();
                SqlDataAdapter1.Update(dtbGen);
                return strNomTabla;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        private String ComandoCreaTabla(DataTable tabla, String nombre)
        {
            try
            {
                String strCad = "CREATE TABLE " + nombre + " (";
                foreach (DataColumn myColumn in tabla.Columns)
                {
                    strCad += myColumn.ColumnName + " ";
                    switch (myColumn.DataType.ToString())
                    {
                        case "System.String":
                            strCad += "varchar (100), ";
                            break;
                        case "System.Double":
                            strCad += "numeric (12, 4), ";
                            break;
                        case "System.Integer":
                            strCad += "numeric (12, 0), ";
                            break;
                        case "System.Decimal":
                            strCad += "numeric (12,4), ";
                            break;
                        case "System.Int32":
                            strCad += "numeric (12, 0), ";
                            break;
                        case "System.DateTime":
                            strCad += "datetime, ";
                            break;
                    }
                }
                strCad = strCad.Substring(0, strCad.Length - 2) + ")";
                return strCad;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public DateTime FechaServidor()
        {
            try
            {
                DataSet DtsRegresa = new DataSet();
                ConectaBD();
                SqlCommand1.CommandText = "select getdate()";
                SqlCommand1.CommandType = CommandType.Text;
                SqlDataAdapter1 = new SqlDataAdapter(SqlCommand1);
                SqlDataAdapter1.Fill(DtsRegresa, "TblFecha");
                if (DtsRegresa.Tables["TblFecha"].Rows.Count == 0)
                    throw new Exception("Error al consultar la hora del servidor");
                else
                    return Convert.ToDateTime(DtsRegresa.Tables["TblFecha"].Rows[0][0]);
            }
            catch (SqlException err)
            {
                throw new Exception("Error al consultar la hora del servidor. " + err.Message, err.InnerException);
            }
        }

        #endregion

    }
}
