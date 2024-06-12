namespace Atos.WebApi.Endpoints.DTO;

public class LimitesTerminalDTO
{
    public int IdPontoAtendimento { get; set; }

    public int CodigoTipoTerminal { get; set; }

    public int? LimSuperior { get; set; }

    public int? LimInferior { get; set; }

    //public virtual TipoTerminal TipoTerminal { get; set; } = null!;

    //public virtual UnidadeInstituicao UnidadeInstituicao { get; set; } = null!;
}