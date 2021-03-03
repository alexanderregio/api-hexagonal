using Hexagonal.Domain.Models;
using System;

namespace Hexagonal.DbAdapter.Validations
{
    public class ValidarUsuarioNulo : IUsuarioValidator
    {
        private IUsuarioValidator nextValidator;

        public ValidarUsuarioNulo(IUsuarioValidator nextValidator)
        {
            this.nextValidator = nextValidator;
        }

        public void Validate(Usuario usuario)
        {
            if (usuario is null)
            {
                throw new ArgumentNullException(nameof(usuario), "Usuário não pode ser nulo");
            }

            nextValidator?.Validate(usuario);
        }
    }
}
