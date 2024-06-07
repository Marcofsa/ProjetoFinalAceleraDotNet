using System;
using System.Collections.Generic;

namespace Atos.WebApi.Endpoints.Models;

public partial class TransacoesInterbancario
{
    public DateTime DataMovimento { get; set; }

    public int Banco { get; set; }

    public int Agencia { get; set; }

    public string Operacao { get; set; } = null!;

    public string Situacao { get; set; } = null!;

    public decimal Valor { get; set; }
}
