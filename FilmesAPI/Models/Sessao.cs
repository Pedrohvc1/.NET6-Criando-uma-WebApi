using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Sessao
{   
    public int? FilmeId { get; set; }
    public virtual Filme Filme { get; set; } //virtual é uma palavra-chave que pode ser usada para modificar um método, propriedade, indexador ou evento e permitir que ele seja substituído em uma classe derivada
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}