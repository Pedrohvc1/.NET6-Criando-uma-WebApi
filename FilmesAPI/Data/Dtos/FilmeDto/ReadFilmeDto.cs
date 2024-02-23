using FilmesAPI.Data.Dtos.SessaoDto;

namespace FilmesAPI.Data.Dtos.FilmeDto;

public class ReadFilmeDto
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Duracao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    public ICollection<ReadSessaoDto> Sessoes { get; set; }

}