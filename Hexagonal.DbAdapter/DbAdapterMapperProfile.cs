using AutoMapper;
using Hexagonal.DbAdapter.Clients;
using Hexagonal.Domain.Models;

namespace Hexagonal.DbAdapter
{
    public class DbAdapterMapperProfile : Profile
    {
        public DbAdapterMapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
