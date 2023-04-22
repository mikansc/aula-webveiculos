using System.ComponentModel.DataAnnotations;
using WebVeiculos.Enums;

namespace WebVeiculos.Dtos
{

  public class CarroCreateDto
  {
    [Required(ErrorMessage = "O campo Marca é obrigatório")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O campo Ano é obrigatório")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "O campo Modelo é obrigatório")]
    public string Modelo { get; set; }

    [Required(ErrorMessage = "O campo Modelo é obrigatório")]
    public string Cor { get; set; }

    [Required(ErrorMessage = "O campo Placa é obrigatório")]
    public string Placa { get; set; }

    [Required(ErrorMessage = "O campo Proprietario é obrigatório")]
    public string Proprietario { get; set; }

    [Required(ErrorMessage = "O campo Proprietario é obrigatório")]
    public CombustivelEnum Combustivel { get; set; }

    [Required(ErrorMessage = "O campo QtdPortas é obrigatório")]
    [Range(2, 4, ErrorMessage = "A quantidade de portas deve ser entre 2 e 4")]
    public int QtdPortas { get; set; }

    [Required(ErrorMessage = "O campo LitragemPortaMalas é obrigatório")]
    public int LitragemPortaMalas { get; set; }

  }
}