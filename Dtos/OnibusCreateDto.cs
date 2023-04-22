using System.ComponentModel.DataAnnotations;
using WebVeiculos.Enums;

namespace WebVeiculos.Dtos
{

  public class OnibusCreateDto
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

    [Required(ErrorMessage = "O campo QtdAssentos é obrigatório")]
    public int QtdAssentos { get; set; }


    [Required(ErrorMessage = "O campo PossuiBanheiro é obrigatório")]
    public bool PossuiBanheiro { get; set; }

    [Required(ErrorMessage = "O campo PossuiWifi é obrigatório")]
    public bool PossuiWifi { get; set; }

    [Required(ErrorMessage = "O campo PossuiTomada é obrigatório")]
    public bool PossuiTomada { get; set; }

    [Required(ErrorMessage = "O campo PossuiTv é obrigatório")]
    public bool PossuiTv { get; set; }
  }
}