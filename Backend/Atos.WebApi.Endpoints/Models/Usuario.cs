using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class Usuario
{
    public string Idusuario { get; set; } = null!;

    public int Idunidadeinstusuario { get; set; }

    public string Descnomeusuario { get; set; } = null!;

    public virtual UnidadeInstituicao UnidadeInstituicao { get; set; } = null!;

    public virtual ICollection<Terminal> Terminals { get; set; } = new List<Terminal>();
}
