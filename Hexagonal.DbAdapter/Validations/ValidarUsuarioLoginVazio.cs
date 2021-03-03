using Hexagonal.Domain.Exceptions;
using Hexagonal.Domain.Models;

namespace Hexagonal.DbAdapter.Validations
{
    public class ValidarUsuarioLoginVazio : IUsuarioValidator
    {
        private readonly IUsuarioValidator nextValidator;

        public ValidarUsuarioLoginVazio(IUsuarioValidator nextValidator)
        {
            this.nextValidator = nextValidator;
        }

        public void Validate(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Login))
            {
                throw new UsuarioCoreException(UsuarioCoreError.LoginNuloOuEspacoVazio(usuario));
            }

            if (!(nextValidator is null))
            {
                nextValidator.Validate(usuario);
            }
        }
    }
}
