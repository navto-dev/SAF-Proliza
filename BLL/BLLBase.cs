using System;
using System.Text;
using System.Security.Cryptography;

namespace BLL
{
    public class BLLBase
    {
        bool BlnIniciaObjBase = false;
        public DAL.DALBase objDALBase;
        public String StrConexion;
        public String StrUsuarioSistema;

        #region "Constructores"
        public BLLBase(String Conexion, String UsuarioSistema)
        {
            StrConexion = Conexion;
            StrUsuarioSistema = UsuarioSistema;
        }

        public BLLBase(string Conexion, string UsuarioSistema, DAL.DALBase DALBase)
        {
            StrConexion = Conexion;
            objDALBase = DALBase;
            BlnIniciaObjBase = true;
            StrUsuarioSistema = UsuarioSistema;
        }

        #endregion


        #region "Metodos"

        public bool InicializaObjConexion()
        {
            try
            {
                if (!BlnIniciaObjBase)
                {
                    objDALBase = new DAL.DALBase(StrConexion);
                    BlnIniciaObjBase = true;
                    return true;
                }
                else return false;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }

        public string CodificaCadena(string cadena)
        {
            try
            {
                MD5 md5;
                md5 = MD5.Create();
                string s = cadena;
                byte[] inbuf = Encoding.UTF8.GetBytes(s);
                byte[] outbuf = md5.ComputeHash(inbuf);
                string hashedPass = Convert.ToBase64String(outbuf);
                return hashedPass;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }


        private string Left(string param, int tam)
        {
            try
            {
                string result = param.Substring(0, tam);
                return result;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }


        private string Right(string param, int tam)
        {
            try
            {
                int value = param.Length - tam;
                string result = param.Substring(value, tam);
                return result;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err.InnerException);
            }
        }


        #endregion

    }
}
