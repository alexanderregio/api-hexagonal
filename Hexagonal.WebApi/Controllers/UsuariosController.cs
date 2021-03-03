using AutoMapper;
using Hexagonal.Domain.Exceptions;
using Hexagonal.Domain.Models;
using Hexagonal.Domain.Services;
using Hexagonal.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hexagonal.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        private readonly IMapper mapper;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            this.usuarioService = usuarioService
                ?? throw new ArgumentNullException(nameof(usuarioService));

            this.mapper = mapper
                ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Olá usuário!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuario(Guid id)
        {
            var usuario = await usuarioService.ObterUsuarioAsync(id);

            if (usuario is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UsuarioDto>(usuario));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuarioAsync(UsuarioDto usuarioDto)
        {
            try
            {
                await usuarioService
                    .CadastrarUsuarioAsync(mapper.Map<Usuario>(usuarioDto));

                var uri = Url.Action("ObterUsuario", new { usuarioDto.Id });

                return Created(uri, "Usuário cadastrado com sucesso!");
            }
            catch (CoreException ex)
            {
                return BadRequest(ex.errors.First().message);
            }
        }
    }
}