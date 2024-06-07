using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class TipoTerminal
{
    public int IdTipoTerminal { get; set; }

    public string DescTerminal { get; set; } = null!;

    public virtual ICollection<LimitesTerminal> LimitesTerminais { get; set; } = new List<LimitesTerminal>();

    public virtual ICollection<Terminal> Terminais { get; set; } = new List<Terminal>();
}
