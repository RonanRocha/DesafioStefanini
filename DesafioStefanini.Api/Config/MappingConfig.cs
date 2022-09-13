using AutoMapper;
using DesafioStefanini.Api.Dto;
using DesafioStefanini.Domain.Entities;

namespace DesafioStefanini.Api.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapppinConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CidadeDto, Cidade>().ReverseMap();
                config.CreateMap<PessoaDto, Pessoa>().ReverseMap();
                config.CreateMap<PessoaQueryDto, Pessoa>().ReverseMap();

            });
            return mapppinConfig;
        }
    }
}
