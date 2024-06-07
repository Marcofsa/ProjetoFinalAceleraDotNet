using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class MovimentacaoPA
{
    public DateTime DataLancamento { get; set; }

    public string CNPJTransportadora { get; set; } = null!;

    public int IdPontoAtendimento { get; set; }

    public int IdTipoTerminal { get; set; }

    public int IdGrupoOpCaixa { get; set; }

    public int IdOperacaoCaixa { get; set; }

    public int Historico { get; set; }

    public decimal Valor { get; set; }

    public virtual TipoTerminal TipoTerminal { get; set; } = null!;

    public virtual TiposOperacao TiposOperacao { get; set; } = null!;

    public virtual TransportadorasPA TransportadorasPA { get; set; } = null!;
}
