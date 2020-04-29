using System.Linq;
using AutoMapper;
using ProjetoContato.Domain.Model;
using ProjetoContato.Domain.Dtos;

namespace ProjetoContato.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Contato, ContatoDto>().ReverseMap();
        }
    }
}