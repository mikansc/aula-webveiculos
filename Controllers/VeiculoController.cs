using Microsoft.AspNetCore.Mvc;
using WebVeiculos.Models;
using WebVeiculos.Dtos;

namespace WebVeiculos.Controllers
{
  [ApiController]
  [Route("api/veiculos")] // https://localhost:1234/api/veiculos
  public class VeiculoController : ControllerBase
  {


    [HttpGet] // https://localhost:1234/api/veiculos
    public ActionResult<List<VeiculoResponseDto>> GetAll()
    {
      var veiculo1 = new Veiculo();
      veiculo1.Marca = "Fiat";
      veiculo1.Ano = 2010;
      veiculo1.Modelo = "Uno";
      veiculo1.Cor = "Vermelho";
      veiculo1.Placa = "ABC-1234";

      var veiculo2 = new Veiculo();
      veiculo2.Marca = "Ford";
      veiculo2.Ano = 2023;
      veiculo2.Modelo = "Focus";
      veiculo2.Cor = "Azul";
      veiculo2.Placa = "ABC-5678";

      var listaDeVeiculos = new List<Veiculo>();
      listaDeVeiculos.Add(veiculo1);
      listaDeVeiculos.Add(veiculo2);

      var listaDeVeiculosResponseDto = new List<VeiculoResponseDto>();

      foreach (var veiculo in listaDeVeiculos)
      {
        var dto = new VeiculoResponseDto(veiculo);
        dto.DataDaConsulta = DateTime.Now;
        listaDeVeiculosResponseDto.Add(dto);
      }

      return Ok(listaDeVeiculosResponseDto);
    }

    [HttpGet("{placa}")] // https://localhost:1234/api/veiculos/ABC-1234
    public ActionResult<Veiculo> Get(
      [FromRoute] string placa
    )
    {

      var veiculo1 = new Veiculo();
      veiculo1.Marca = "Fiat";
      veiculo1.Ano = 2010;
      veiculo1.Modelo = "Uno";
      veiculo1.Cor = "Vermelho";
      veiculo1.Placa = "ABC-1234";

      var veiculo2 = new Veiculo();
      veiculo2.Marca = "Ford";
      veiculo2.Ano = 2023;
      veiculo2.Modelo = "Focus";
      veiculo2.Cor = "Azul";
      veiculo2.Placa = "ABC-5678";

      var listaDeVeiculos = new List<Veiculo>();
      listaDeVeiculos.Add(veiculo1);
      listaDeVeiculos.Add(veiculo2);

      var veiculoResposta = listaDeVeiculos.FirstOrDefault(veiculo => veiculo.Placa == placa);

      if (veiculoResposta == null)
      {
        return NotFound($"Veículo não encontrado com a placa {placa}!");
      }

      return Ok(veiculoResposta);
    }

    [HttpPost] // https://localhost:1234/api/veiculos
    public ActionResult<Veiculo> Create(
      [FromBody] VeiculoCreateDto veiculoDoBody
    )
    {
      var veiculo = new Veiculo();
      veiculo.Marca = veiculoDoBody.Marca;
      veiculo.Ano = veiculoDoBody.Ano;
      veiculo.Modelo = veiculoDoBody.Modelo;
      veiculo.Cor = veiculoDoBody.Cor;
      veiculo.Placa = veiculoDoBody.Placa;
      veiculo.Combustivel = Enums.CombustivelEnum.FLEX;

      return Created($"/{veiculoDoBody.Proprietario}", veiculo);
    }

  }
}