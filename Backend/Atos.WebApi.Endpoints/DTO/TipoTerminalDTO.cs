namespace Atos.WebApi.Endpoints.DTO;

public class TipoTerminalDTO
{
    public int IdTipoTerminal { get; set; }

    public string DescTerminal { get; set; } = null!;

    public virtual ICollection<LimitesTerminal> LimitesTerminais { get; set; } = new List<LimitesTerminal>();

    public virtual ICollection<Terminal> Terminais { get; set; } = new List<Terminal>();
}