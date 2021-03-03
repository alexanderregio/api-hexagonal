using System;

namespace Hexagonal.DbAdapter.Clients
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
