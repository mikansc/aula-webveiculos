using Microsoft.AspNetCore.Mvc;
using WebVeiculos.Data;
using WebVeiculos.Models;
using WebVeiculos.Dtos;

namespace WebVeiculos.Controllers
{
  [ApiController]
  [Route("api/onibus")] // Ex: https://localhost:1234/api/onibus
  public class OnibusController : ControllerBase
  {

    // Este exemplo de controller usa o context como um parâmetro do método
    // de cada rota, utilizando o [FromServices] para dizer ao .Net que
    // o parâmetro é de um serviço (banco de dados).
    // O serviço é cadastrado no Program.cs, na linha 15.


    [HttpGet] // Ex: https://localhost:1234/api/onibus
    public ActionResult<List<OnibusResponseDto>> GetAll(
      [FromServices] WebVeiculosContext context
      )
    {
      var listaOnibus = context.Onibus;
      var veiculosResponseDto = new List<OnibusResponseDto>();
      foreach (var veiculo in listaOnibus)
      {
        var dto = new OnibusResponseDto(veiculo);
        dto.DataDaConsulta = DateTime.Now;
        veiculosResponseDto.Add(dto);
      }
      return Ok(veiculosResponseDto);
    }

    [HttpGet("{placa}")] // Ex: https://localhost:1234/api/onibus/ABC-1234
    public ActionResult<OnibusResponseDto> Get(
      [FromRoute] string placa,
      [FromServices] WebVeiculosContext context
    )
    {
      var onibus = context.Onibus.FirstOrDefault(c => c.Placa == placa);
      if (onibus == null)
      {
        return NotFound($"Veículo não encontrado com a placa {placa}!");
      }
      return Ok(new OnibusResponseDto(onibus));
    }

    [HttpPost] // Ex: https://localhost:1234/api/onibus
    public ActionResult<OnibusResponseDto> Create(
      [FromBody] OnibusCreateDto veiculoDoBody,
      [FromServices] WebVeiculosContext context
    )
    {
      var veiculo = new Onibus();
      veiculo.Marca = veiculoDoBody.Marca;
      veiculo.Ano = veiculoDoBody.Ano;
      veiculo.Modelo = veiculoDoBody.Modelo;
      veiculo.Cor = veiculoDoBody.Cor;
      veiculo.Placa = veiculoDoBody.Placa;
      veiculo.Combustivel = Enums.CombustivelEnum.FLEX;

      context.Onibus.Add(veiculo);
      context.SaveChanges();

      return Created($"/api/onibus/{veiculoDoBody.Placa}", new OnibusResponseDto(veiculo));
    }

    [HttpPut("{placa}")] // Ex: https://localhost:1234/api/onibus/ABC-1234
    public ActionResult<OnibusResponseDto> Update(
      [FromRoute] string placa,
      [FromBody] OnibusCreateDto veiculoDoBody,
      [FromServices] WebVeiculosContext context
    )
    {
      var onibus = context.Onibus.FirstOrDefault(o => o.Placa == placa);
      if (onibus == null)
      {
        return NotFound($"Veículo não encontrado com a placa {placa}!");
      }
      onibus.Marca = veiculoDoBody.Marca;
      onibus.Ano = veiculoDoBody.Ano;
      onibus.Modelo = veiculoDoBody.Modelo;
      onibus.Cor = veiculoDoBody.Cor;
      onibus.Placa = veiculoDoBody.Placa;
      onibus.Combustivel = veiculoDoBody.Combustivel;

      context.Onibus.Update(onibus);
      context.SaveChanges();

      return Ok(new OnibusResponseDto(onibus));
    }

    [HttpDelete("{placa}")] // Ex: https://localhost:1234/api/onibus/ABC-1234
    public ActionResult Delete(
      [FromRoute] string placa,
      [FromServices] WebVeiculosContext context
    )
    {
      var onibus = context.Onibus.FirstOrDefault(c => c.Placa == placa);
      if (onibus == null)
      {
        return NotFound($"Veículo não encontrado com a placa {placa}!");
      }
      context.Onibus.Remove(onibus);
      context.SaveChanges();

      return NoContent();
    }
  }
}