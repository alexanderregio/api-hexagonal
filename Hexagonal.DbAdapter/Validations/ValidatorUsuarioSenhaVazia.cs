using Hexagonal.Domain.Exceptions;
using Hexagonal.Domain.Models;

namespace Hexagonal.DbAdapter.Validations
{
    public class ValidatorUsuarioSenhaVazia : IUsuarioValidator
    {
        private readonly IUsuarioValidator nextValidator;

        public ValidatorUsuarioSenhaVazia(IUsuarioValidator nextValidator)
        {
            this.nextValidator = nextValidator;
        }

        public void Validate(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Senha))
            {
                throw new UsuarioCoreException(UsuarioCoreError.SenhaNulaOuEspacoVazio(usuario));
            }

            nextValidator?.Validate(usuario);
        }
    }
}
