using WebVeiculos.Enums;

namespace WebVeiculos.Models
{

  public class Veiculo
  {
    public string Marca { get; set; }
    public int Ano { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public string Placa { get; set; }
    public CombustivelEnum Combustivel { get; set; }
  }
}