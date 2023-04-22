namespace WebVeiculos.Models;

public class Onibus : Veiculo
{
    public int QtdAssentos { get; set; }
    public bool PossuiBanheiro { get; set; }
    public bool PossuiWifi { get; set; }
    public bool PossuiTomada { get; set; }
    public bool PossuiTv { get; set; }
}