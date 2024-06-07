using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class TiposOperacao
{
    public int IdGrupoOpCaixa { get; set; }

    public int IdOperacaoCaixa { get; set; }

    public string DescricaoOperacao { get; set; } = null!;

    public int Historico { get; set; }

    public string DescricaoHistorico { get; set; } = null!;

    public bool? Sensibilizacao { get; set; }
}
