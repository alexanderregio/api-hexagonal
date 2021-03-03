using Hexagonal.Domain.Models;

namespace Hexagonal.Domain.Exceptions
{
    public class UsuarioCoreException : CoreException
    {
        public UsuarioCoreException(params UsuarioCoreError[] errors)
            : base(errors) { }
    }

    public class UsuarioCoreError : CoreError
    {
        public UsuarioCoreError(string key, string message)
            : base(key, message) { }

        public static UsuarioCoreError LoginNuloOuEspacoVazio(Usuario usuario)
            => new UsuarioCoreError("LoginNuloOuEspacoVazio", "O login do usuário não pode ser nulo ou vazio.");

        public static UsuarioCoreError SenhaNulaOuEspacoVazio(Usuario usuario)
            => new UsuarioCoreError("SenhaNulaOuEspacoVazio", "O senha do usuário não pode ser nula ou vazia.");
    }

}