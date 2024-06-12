namespace Atos.WebApi.Endpoints.Models;

public partial class MovimentacaoPA
{
    public DateTime DataLancamento { get; set; }

    public int IdPontoAtendimento { get; set; }

    public int NumTerminal { get; set; }

    public int IdGrupoOpCaixa { get; set; }

    public int IdOperacaoCaixa { get; set; }

    public int Historico { get; set; }

    public decimal Valor { get; set; }

    public virtual TiposOperacao TiposOperacao { get; set; } = null!;

    public virtual Terminal Terminal { get; set; } = null!;
}
