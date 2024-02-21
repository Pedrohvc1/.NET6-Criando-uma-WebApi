using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDto;

public class UpdateCinemaDto
{

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Nome { get; set; }
}