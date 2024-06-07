using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class Terminal
{
    public int IdUnidadeiIst { get; set; }

    public int NumTerminal { get; set; }

    public int IdTipoTerminal { get; set; }

    public string? Idusuario { get; set; }

    public virtual TipoTerminal TipoTerminal { get; set; } = null!;

    public virtual UnidadeInstituicao UnidadeInstituicao { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
