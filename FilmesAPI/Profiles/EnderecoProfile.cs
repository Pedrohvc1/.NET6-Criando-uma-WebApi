using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateCinemaDto, Endereco>();
        CreateMap<Endereco, ReadCinemaDto>();
        CreateMap<UpdateCinemaDto, Endereco>();
    }
}