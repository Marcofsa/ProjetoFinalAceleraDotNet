using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class UnidadeInstituicao
{
    public int IdUnidadeInst { get; set; }

    public string NomeUnidade { get; set; } = null!;

    public int CodTipoUnidade { get; set; }

    public virtual ICollection<LimitesTerminal> LimitesTerminais { get; set; } = new List<LimitesTerminal>();

    public virtual ICollection<Terminal> Terminais { get; set; } = new List<Terminal>();

    public virtual ICollection<TransportadorasPA> TransportadorasPAs { get; set; } = new List<TransportadorasPA>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
