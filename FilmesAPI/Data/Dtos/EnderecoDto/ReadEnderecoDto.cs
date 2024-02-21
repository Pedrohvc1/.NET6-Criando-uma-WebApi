using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.EnderecoDto;

public class ReadEnderecoDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
}