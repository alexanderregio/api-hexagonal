using Hexagonal.Domain.Adapters;
using Hexagonal.Domain.Models;
using Hexagonal.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Hexagonal.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IDbAdapter dbAdapter;
        private readonly ILogger logger;

        public UsuarioService(IDbAdapter dbAdapter, ILoggerFactory loggerFactory)
        {
            this.dbAdapter = dbAdapter
                ?? throw new ArgumentNullException(nameof(dbAdapter));

            logger = loggerFactory?.CreateLogger<UsuarioService>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task CadastrarUsuarioAsync(Usuario usuario)
        {
            logger.LogInformation("Begin...");

            await dbAdapter.CadastrarUsuarioAsync(usuario);

            logger.LogInformation("End...");
        }

        public async Task<Usuario> ObterUsuarioAsync(Guid id)
        {
            logger.LogInformation("Begin...");

            var usuario = await dbAdapter.ObterUsuarioAsync(id);

            logger.LogInformation("End...");

            return usuario;
        }
    }
}
