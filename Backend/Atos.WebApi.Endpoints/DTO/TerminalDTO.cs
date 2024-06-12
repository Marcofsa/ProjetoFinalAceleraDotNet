using Microsoft.EntityFrameworkCore;

namespace Atos.WebApi.Endpoints.DTO;

public class TerminalDTO
{
    public int IdUnidadeInst { get; set; }

    public int NumTerminal { get; set; }

    public int IdTipoTerminal { get; set; }

    public string? NomeUsuario { get; set; }
    public decimal SaldoTotal { get; set; }
    public int? LimSuperior { get; set; }

    public int? LimInferior { get; set; }
    public int? Mediana { get; set; }

    public virtual ICollection<MovimentacaoPADTO> Movimentacoes { get; set; } = new List<MovimentacaoPADTO>();

    //public virtual TipoTerminal TipoTerminal { get; set; } = null!;

    //public virtual UnidadeInstituicao UnidadeInstituicao { get; set; } = null!;

    //public virtual Usuario? Usuario { get; set; }
}