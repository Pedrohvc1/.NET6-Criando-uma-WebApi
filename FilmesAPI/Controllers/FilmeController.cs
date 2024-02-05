using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) // [FromBody] vem do corpo da requisição
    {
        Filme filme = _mapper.Map<Filme>(filmeDto); // Map é um método que mapeia um objeto de um tipo para um objeto de outro tipo

        _context.Filmes.Add(filme);
        _context.SaveChanges(); // SaveChanges é um método que salva todas as alterações feitas no contexto do banco de dados
        return CreatedAtAction(nameof(RecuperaFilmeId), new { id = filme.Id }, filme); // CreatedAtAction é um método que retorna um código de status 201 com os parametros: nome da ação, valores dos parâmetros e o objeto a ser retornado
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip, [FromQuery] int take)
    // IEnumerable é uma interface que representa uma coleção de objetos que podem ser enumerados
    // FromQuery é um atributo que indica que os parâmetros da ação devem ser obtidos da string de consulta da solicitação
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id) // IActionResult é uma interface que representa o resultado de um método de ação
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound(); // NotFound é um método que retorna um código de status 404
        return Ok(filme);
    }
}
