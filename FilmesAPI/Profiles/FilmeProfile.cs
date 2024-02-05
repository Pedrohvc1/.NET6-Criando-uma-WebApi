using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
    }
}