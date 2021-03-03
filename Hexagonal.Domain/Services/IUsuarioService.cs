using Hexagonal.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Hexagonal.Domain.Services
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtém um usuário cadastrado
        /// </summary>
        /// <param name="id">Identificador do usuário cadastrado</param>
        /// <returns>Dados do usuário cadastrado</returns>
        Task<Usuario> ObterUsuarioAsync(Guid id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Usuário a ser cadastrado</param>
        Task CadastrarUsuarioAsync(Usuario usuario);
    }
}
