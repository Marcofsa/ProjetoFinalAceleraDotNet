using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class LimitesTerminal
{
    public int IdPontoAtendimento { get; set; }

    public int CodigoTipoTerminal { get; set; }

    public int? LimSuperior { get; set; }

    public int? LimInferior { get; set; }

    public virtual TipoTerminal TipoTerminal { get; set; } = null!;

    public virtual UnidadeInstituicao UnidadeInstituicao { get; set; } = null!;
}
