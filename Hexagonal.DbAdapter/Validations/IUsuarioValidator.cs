using Hexagonal.Domain.Models;

namespace Hexagonal.DbAdapter.Validations
{
    public interface IUsuarioValidator
    {
        /// <summary>
        /// Valida os dados do usuário
        /// </summary>
        /// <param name="usuario">Usuário a ser validado</param>
        void Validate(Usuario usuario);

        /// <summary>
        /// Registra o próximo validador
        /// </summary>
        /// <param name="validator"></param>
        //void SetNext(IUsuarioValidator validator);
    }
}