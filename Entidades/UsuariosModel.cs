namespace Entidades
{
    public class UsuariosModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Pasword { get; set; }
        public int IdRol { get; set; }
        public string email { get; set; }
        public bool Activo { get; set; }
    }
}
