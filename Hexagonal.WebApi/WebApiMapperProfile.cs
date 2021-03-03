using AutoMapper;
using Hexagonal.Domain.Models;
using Hexagonal.WebApi.Dtos;

namespace Hexagonal.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
