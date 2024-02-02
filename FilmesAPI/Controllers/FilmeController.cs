using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] Filme filme) // [FromBody] vem do corpo da requisição
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmeId), new { id = filme.Id }, filme); // CreatedAtAction é um método que retorna um código de status 201 com os parametros: nome da ação, valores dos parâmetros e o objeto a ser retornado
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip, [FromQuery] int take)
    // IEnumerable é uma interface que representa uma coleção de objetos que podem ser enumerados
    // FromQuery é um atributo que indica que os parâmetros da ação devem ser obtidos da string de consulta da solicitação
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id) // IActionResult é uma interface que representa o resultado de um método de ação
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound(); // NotFound é um método que retorna um código de status 404
        return Ok(filme);
    }
}
