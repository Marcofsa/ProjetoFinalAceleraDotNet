namespace Atos.WebApi.Endpoints.DTO
{
    public class MovimentacaoPADTO
    {
        public DateTime DataLancamento { get; set; }

        public int IdPontoAtendimento { get; set; }

        public int NumTerminal { get; set; }

        public string CodigoOperacao {  get; set; }

        public int IdGrupoOpCaixa { get; set; }

        public int IdOperacaoCaixa { get; set; }

        public string DescOperacao {  get; set; }

        public int Historico { get; set; }

        public string DescHistorico { get; set; }

        public decimal Valor { get; set; }

        public virtual TipoTerminal TipoTerminal { get; set; } = null!;

        public virtual TiposOperacao TiposOperacao { get; set; } = null!;

        public virtual Terminal Terminal { get; set; } = null!;
    }
}
