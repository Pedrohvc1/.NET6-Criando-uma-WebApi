using AutoMapper;
using FilmesAPI.Data.Dtos.CinemaDto;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco,
                       opt => opt.MapFrom(cinema => cinema.Endereco)); // mapeamento personalizado para o campo Endereco do Cinema
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}