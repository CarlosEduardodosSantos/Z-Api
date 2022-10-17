using System;

namespace Api.Zip.Models
{
    public class UsuariosGestor
    {
        public Guid UserID { get; set; }
        public string nome { get; set; }
        public string Senha { get; set; }
        public string email { get; set; }
        public string fone { get; set; }

    }
}
