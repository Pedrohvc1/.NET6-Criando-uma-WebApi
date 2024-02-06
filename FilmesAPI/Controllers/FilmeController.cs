using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

/// <summary>
/// Controller responsável por gerenciar os filmes
/// </summary>
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


    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto"> Objeto com os campos necessários para a criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Retorna o filme recém-criado com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) // [FromBody] vem do corpo da requisição
    {
        Filme filme = _mapper.Map<Filme>(filmeDto); // Map é um método que mapeia um objeto de um tipo para um objeto de outro tipo
        _context.Filmes.Add(filme);
        _context.SaveChanges(); // SaveChanges é um método que salva todas as alterações feitas no contexto do banco de dados
        return CreatedAtAction(nameof(RecuperaFilmeId), new { id = filme.Id }, filme); // CreatedAtAction é um método que retorna um código de status 201 com os parametros: nome da ação, valores dos parâmetros e o objeto a ser retornado
    }


    /// <summary>
    /// Recupera uma lista de filmes
    /// </summary>
    /// <param name="skip">Quantidade de filmes a serem pulados</param>
    /// <param name="take">Quantidade de filmes a serem retornados</param>
    /// <returns>Uma lista de filmes</returns>
    /// <response code="200">Retorna a lista de filmes com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip, [FromQuery] int take)
    // IEnumerable é uma interface que representa uma coleção de objetos que podem ser enumerados
    // FromQuery é um atributo que indica que os parâmetros da ação devem ser obtidos da string de consulta da solicitação
    {
        // return _context.Filmes.Skip(skip).Take(take);
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take)); // a mudança foi feita para mapear a lista de filmes para uma lista de ReadFilmeDto
    }

    /// <summary>
    /// Recupera um filme pelo id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>único filme</returns>
    /// <response code="200">Retorna o filme com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RecuperaFilmeId(int id) // IActionResult é uma interface que representa o resultado de um método de ação
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound(); // NotFound é um método que retorna um código de status 404

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    /// <summary>
    /// Atualiza um filme
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filmeDto"></param>
    /// <returns></returns>
    /// <response code="204">Retorna o filme atualizado com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent(); // NoContent é um método que retorna um código de status 204 sem conteúdo
    }

    /// <summary>
    /// Atualiza parcialmente um filme
    /// </summary>
    /// <param name="id"></param>
    /// <param name="path"></param>
    /// <returns>Atualiza parcialmente um filme e não é necessário enviar todos os campos</returns>
    /// <response code="204">Retorna o filme atualizado com sucesso</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaParcialFilme(int id, [FromBody] JsonPatchDocument<UpdateFilmeDto> path)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        path.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar)) return ValidationProblem(ModelState);

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um filme
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204">Retorna o filme deletado com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}
