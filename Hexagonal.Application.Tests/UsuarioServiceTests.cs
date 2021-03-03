using Hexagonal.Domain.Adapters;
using Hexagonal.Domain.Exceptions;
using Hexagonal.Domain.Models;
using Hexagonal.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hexagonal.Application.Tests
{
    public class UsuarioServiceTests
    {
        private readonly IUsuarioService usuarioService;
        private readonly Mock<IDbAdapter> dbAdapterMock;

        public UsuarioServiceTests()
        {
            dbAdapterMock = new Mock<IDbAdapter>();

            usuarioService = new UsuarioService(dbAdapterMock.Object,
                                                new LoggerFactory());
        }

        [Fact]
        [Trait(nameof(IUsuarioService.CadastrarUsuarioAsync), "Sucesso")]
        public async void CadastrarUsuarioAsync_Sucesso()
        {
            Usuario usuario = new Usuario
            {
                Id = new Guid(),
                Login = "LoginTest",
                Senha = "SecretPassword"
            };

            dbAdapterMock
                .Setup(m => m.CadastrarUsuarioAsync(It.IsAny<Usuario>()))
                .Returns(Task.CompletedTask);

            await usuarioService.CadastrarUsuarioAsync(usuario);

            dbAdapterMock
                .Verify(m => m.CadastrarUsuarioAsync(It.IsAny<Usuario>()), Times.Once());
        }

        [Fact]
        [Trait(nameof(IUsuarioService.CadastrarUsuarioAsync), "Erro")]
        public async void CadastrarUsuarioAsync_Erro()
        {
            dbAdapterMock
                .Setup(m => m.CadastrarUsuarioAsync(It.IsAny<Usuario>()))
                .ThrowsAsync(new ArgumentException("Usuário não pode ser nulo"));

            var expectedException = await Assert.ThrowsAsync<ArgumentException>
                (async () => await usuarioService.CadastrarUsuarioAsync(null));

            Assert.Contains("Usuário não pode ser nulo", expectedException.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [Trait(nameof(IUsuarioService.CadastrarUsuarioAsync), "CoreErrorLoginNuloOuEspacoVazio")]
        public async void CadastrarUsuarioAsync_CoreErrorLoginNuloOuEspacoVazio(string login)
        {
            Usuario usuario = new Usuario
            {
                Id = new Guid(),
                Login = login,
                Senha = "SecretPassword"
            };


            dbAdapterMock
                .Setup(m => m.CadastrarUsuarioAsync(It.IsAny<Usuario>()))
                .ThrowsAsync(new UsuarioCoreException(UsuarioCoreError.LoginNuloOuEspacoVazio(It.IsAny<Usuario>())));

            var expectedException = await Assert.ThrowsAsync<UsuarioCoreException>
                (async () => await usuarioService.CadastrarUsuarioAsync(usuario));

            var expectedMessageException = expectedException.errors.First().message;

            Assert.Contains("O login do usuário não pode ser nulo ou vazio.", expectedMessageException);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [Trait(nameof(IUsuarioService.CadastrarUsuarioAsync), "CoreErrorSenhaNulaOuEspacoVazio")]
        public async void CadastrarUsuarioAsync_CoreErrorSenhaNulaOuEspacoVazio(string senha)
        {
            Usuario usuario = new Usuario
            {
                Id = new Guid(),
                Login = "LoginTest",
                Senha = senha
            };


            dbAdapterMock
                .Setup(m => m.CadastrarUsuarioAsync(It.IsAny<Usuario>()))
                .ThrowsAsync(new UsuarioCoreException(UsuarioCoreError.SenhaNulaOuEspacoVazio(It.IsAny<Usuario>())));

            var expectedException = await Assert.ThrowsAsync<UsuarioCoreException>
                (async () => await usuarioService.CadastrarUsuarioAsync(usuario));

            var expectedMessageException = expectedException.errors.First().message;

            Assert.Contains("O senha do usuário não pode ser nula ou vazia.", expectedMessageException);
        }

        [Fact]
        [Trait(nameof(IUsuarioService.ObterUsuarioAsync), "Sucesso")]
        public async void ObterUsuarioAsync_Sucesso()
        {
            Usuario expectedUsuario = new Usuario
            {
                Id = new Guid(),
                Login = "LoginTest",
                Senha = "SecretPassword"
            };

            dbAdapterMock
                .Setup(f => f.ObterUsuarioAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedUsuario);

            var actualUsuario = await usuarioService.ObterUsuarioAsync(new Guid());

            Assert.Equal(expectedUsuario.Id, actualUsuario.Id);
            Assert.Equal(expectedUsuario.Login, actualUsuario.Login);
            Assert.Equal(expectedUsuario.Senha, actualUsuario.Senha);
        }

        [Fact]
        [Trait(nameof(IUsuarioService.ObterUsuarioAsync), "SucessoNull")]
        public async void ObterUsuarioAsync_SucessoNull()
        {
            Usuario expectedUsuario = null;

            dbAdapterMock
                .Setup(f => f.ObterUsuarioAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedUsuario);

            var actualUsuario = await usuarioService.ObterUsuarioAsync(new Guid());

            Assert.Null(actualUsuario);
        }
    }
}
