using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Data.Dtos.SessaoDto;

namespace FilmesAPI.Data.Dtos.CinemaDto;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
    public ICollection<ReadSessaoDto> Sessoes { get; set; }

}