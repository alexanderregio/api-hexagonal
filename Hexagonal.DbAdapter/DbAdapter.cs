using AutoMapper;
using Hexagonal.DbAdapter.Clients;
using Hexagonal.DbAdapter.Validations;
using Hexagonal.Domain.Adapters;
using Hexagonal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hexagonal.DbAdapter
{
    public class DbAdapter : IDbAdapter
    {
        private IList<UsuarioDto> usuarios;

        private readonly DbAdapterConfiguration configuration;
        private readonly IMapper mapper;

        public DbAdapter(DbAdapterConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration
                ?? throw new ArgumentNullException(nameof(configuration));

            this.mapper = mapper
                ?? throw new ArgumentException(nameof(mapper));

            usuarios = new List<UsuarioDto>();
        }

        public async Task CadastrarUsuarioAsync(Usuario usuario)
        {
            var validarUsuarioNulo =
                new ValidarUsuarioNulo(
                    new ValidarUsuarioLoginVazio(
                        new ValidatorUsuarioSenhaVazia(null)));

            validarUsuarioNulo.Validate(usuario);

            await Task.Run(() => usuarios.Add(
                mapper.Map<UsuarioDto>(usuario)));
        }

        public async Task<Usuario> ObterUsuarioAsync(Guid id)
        {
            var usuarioDto = usuarios
                .Where(u => u.Id == id)
                .FirstOrDefault();

            return await Task.Run(
                () => usuarioDto is null 
                ? null 
                : mapper.Map<Usuario>(usuarioDto));
        }
    }
}
