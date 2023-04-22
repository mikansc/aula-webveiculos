using WebVeiculos.Models;

namespace WebVeiculos.Dtos
{
  public class OnibusResponseDto
  {
    public string MarcaModelo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }

    public bool ehSeminovo { get; set; }
    public DateTime DataDaConsulta { get; set; }

    public OnibusResponseDto(Onibus veiculo)
    {
      Marca = veiculo.Marca;
      Modelo = veiculo.Modelo;
      Ano = veiculo.Ano;
      MarcaModelo = $"{veiculo.Marca} {veiculo.Modelo}";
      ehSeminovo = veiculo.Ano > 2020;
    }

  }
}