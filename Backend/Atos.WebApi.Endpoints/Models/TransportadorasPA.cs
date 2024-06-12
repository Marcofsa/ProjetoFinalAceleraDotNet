namespace Atos.WebApi.Endpoints.Models;

public partial class TransportadorasPA
{
    public string CNPJTransportadora { get; set; } = null!;

    public int IdPontoAtendimento { get; set; }

    public virtual UnidadeInstituicao UnidadeInstituicao { get; set; } = null!;
}
