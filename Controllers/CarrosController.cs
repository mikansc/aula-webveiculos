using Microsoft.AspNetCore.Mvc;
using WebVeiculos.Data;
using WebVeiculos.Models;
using WebVeiculos.Dtos;

namespace WebVeiculos.Controllers
{
  [ApiController]
  [Route("api/carros")] // https://localhost:1234/api/carros
  public class CarrosController : ControllerBase
  {
    // Este exemplo usa o _context como uma propriedade da classe
    // (este underline antes do nome "context" é uma convenção para
    // propriedades privadas, mas não é obrigatório).
    private readonly WebVeiculosContext _context;
    public CarrosController(WebVeiculosContext context)
    {
      // O .Net adiciona o WebVeiculosContext como um serviço no construtor
      // da classe. Então, pegamos esse context e atribuímos à propriedade _context
      // interna.
      _context = context;
    }

    [HttpGet] // Ex: https://localhost:1234/api/carros
    public ActionResult<List<CarroResponseDto>> GetAll(
      [FromQuery] string marca
      )
    {
      // uso do _context interno para buscar os dados da tabela Carros
      // filtrando os carros caso seja informado query param
      var carros = new List<Carro>();
      if (!string.IsNullOrEmpty(marca))
      {
        carros = _context.Carros.Where(c => c.Marca == marca).ToList();
      }
      else
      {
        carros = _context.Carros.ToList();
      }

      var veiculosResponseDto = new List<CarroResponseDto>();
      foreach (var veiculo in carros)
      {
        var dto = new CarroResponseDto(veiculo);
        dto.DataDaConsulta = DateTime.Now;
        veiculosResponseDto.Add(dto);
      }
      return Ok(veiculosResponseDto);
    }

    [HttpGet("{placa}")] // Ex: https://localhost:1234/api/carros/ABC-1234
    public ActionResult<CarroResponseDto> Get([FromRoute] string placa)
    {
      var carro = _context.Carros.FirstOrDefault(c => c.Placa == placa);
      if (carro == null)
      {
        return NotFound($"Veículo não encontrado com a placa {placa}!");
      }
      return Ok(new CarroResponseDto(carro));
    }

    [HttpPost] // Ex: https://localhost:1234/api/carros
    public ActionResult<CarroResponseDto> Create([FromBody] CarroCreateDto veiculoDoBody)
    {
      var veiculo = new Carro();
      veiculo.Marca = veiculoDoBody.Marca;
      veiculo.Ano = veiculoDoBody.Ano;
      veiculo.Modelo = veiculoDoBody.Modelo;
      veiculo.Cor = veiculoDoBody.Cor;
      veiculo.Placa = veiculoDoBody.Placa;
      veiculo.Combustivel = Enums.CombustivelEnum.FLEX;

      _context.Carros.Add(veiculo);
      _context.SaveChanges();

      return Created($"/api/carros/{veiculoDoBody.Placa}", new CarroResponseDto(veiculo));
    }

    [HttpPut("{placa}")]
    public ActionResult<CarroResponseDto> Update([FromRoute] string placa, [FromBody] CarroCreateDto veiculoDoBody)
    {
      var carro = _context.Carros.FirstOrDefault(c => c.Placa == placa);
      if (carro == null)
      {
        return NotFound($"Veículo não encontrado com a placa {placa}!");
      }
      carro.Marca = veiculoDoBody.Marca;
      carro.Ano = veiculoDoBody.Ano;
      carro.Modelo = veiculoDoBody.Modelo;
      carro.Cor = veiculoDoBody.Cor;
      carro.Placa = veiculoDoBody.Placa;
      carro.Combustivel = veiculoDoBody.Combustivel;

      _context.Carros.Update(carro);
      _context.SaveChanges();

      return Ok(new CarroResponseDto(carro));
    }

    [HttpDelete("{placa}")]
    public ActionResult Delete([FromRoute] string placa)
    {
      var carro = _context.Carros.FirstOrDefault(c => c.Placa == placa);
      if (carro == null)
      {
        return NotFound($"Veículo não encontrado com a placa {placa}!");
      }
      _context.Carros.Remove(carro);
      _context.SaveChanges();
      return NoContent();
    }
  }
}