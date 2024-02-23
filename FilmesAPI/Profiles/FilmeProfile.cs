using FilmesAPI.Models;
using AutoMapper;
using FilmesAPI.Data.Dtos.FilmeDto;

namespace FilmesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>()
            .ForMember(FilmeDto => FilmeDto.Sessoes,
                       opt => opt.MapFrom(filme => filme.Sessoes));
    }
}