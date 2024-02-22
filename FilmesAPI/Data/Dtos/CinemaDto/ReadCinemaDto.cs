using FilmesAPI.Data.Dtos.EnderecoDto;

namespace FilmesAPI.Data.Dtos.CinemaDto;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
}