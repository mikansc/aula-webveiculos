using System.ComponentModel.DataAnnotations;
using WebVeiculos.Enums;

namespace WebVeiculos.Dtos
{

  public class VeiculoCreateDto
  {
    [Required(ErrorMessage = "O campo Marca é obrigatório")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O campo Ano é obrigatório")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "O campo Modelo é obrigatório")]
    public string Modelo { get; set; }

    public string Cor { get; set; }

    public string Placa { get; set; }
    public string Proprietario { get; set; }

    public CombustivelEnum Combustivel { get; set; }
  }
}