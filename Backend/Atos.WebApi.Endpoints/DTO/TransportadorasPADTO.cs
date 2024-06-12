namespace Atos.WebApi.Endpoints.DTO;

public class TransportadorasPADTO
{
    public string CNPJTransportadora { get; set; } = null!;

    public int IdPontoAtendimento { get; set; }

    public virtual UnidadeInstituicaoDTO UnidadeInstituicao { get; set; } = null!;
}