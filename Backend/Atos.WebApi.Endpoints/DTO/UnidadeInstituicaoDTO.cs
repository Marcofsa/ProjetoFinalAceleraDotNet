namespace Atos.WebApi.Endpoints.DTO;

public class UnidadeInstituicaoDTO
{
    public int IdUnidadeInst { get; set; }

    public string NomeUnidade { get; set; } = null!;

    public int CodTipoUnidade { get; set; }

    public decimal SaldoTotal { get; set; }
    public DateTime DataUltimaAtualizacao { get; set; }

    //public virtual ICollection<LimitesTerminalDTO> LimitesTerminais { get; set; } = new List<LimitesTerminalDTO>();

    public virtual ICollection<TerminalDTO> Terminais { get; set; } = new List<TerminalDTO>();

    //public virtual ICollection<TransportadorasPADTO> TransportadorasPAs { get; set; } = new List<TransportadorasPADTO>();

    //public virtual ICollection<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
}