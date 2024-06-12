using Atos.WebApi.Endpoints.DTO;
using Atos.WebApi.Endpoints.Models;
using Microsoft.EntityFrameworkCore;

namespace Atos.WebApi.Endpoints.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnidadeInstituicoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnidadeInstituicoesController(ApplicationDbContext context)
        {      
            _context = context;
        }

        // GET: api/v1/UnidadeInstituicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeInstituicao>>> GetUnidadeInstituicoes()
        {
            return await _context.UnidadeInstituicoes.ToListAsync();
        }

        // GET: api/v1/UnidadeInstituicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeInstituicaoDTO>> GetUnidadeInstituicao(int id)
        {
            decimal saldoTotalPA = await CalcularSaldoTotalPA(id);
            DateTime dataUltimoLancamentoPA = await BuscarDataUltimoLancamentoPA(id);

            UnidadeInstituicao pa = await _context.UnidadeInstituicoes
                .Include(pa => pa.Terminais)
                    .ThenInclude(terminal => terminal.Usuario)
                .Include(pa => pa.LimitesTerminais)
                .FirstOrDefaultAsync(pa => pa.IdUnidadeInst == id);

            UnidadeInstituicaoDTO? paRetorno = new UnidadeInstituicaoDTO()
            {
                IdUnidadeInst = pa.IdUnidadeInst,
                NomeUnidade = pa.NomeUnidade,
                CodTipoUnidade = pa.CodTipoUnidade,
                SaldoTotal = saldoTotalPA,
                DataUltimaAtualizacao = dataUltimoLancamentoPA,
            };
            
            List<LimitesTerminalDTO> listagemLimitesTerminais = pa.LimitesTerminais.Select(lim => new LimitesTerminalDTO()
            {
                IdPontoAtendimento = lim.IdPontoAtendimento,
                CodigoTipoTerminal = lim.CodigoTipoTerminal,
                LimInferior = lim.LimInferior,
                LimSuperior = lim.LimSuperior,
            }).ToList();

            List<TerminalDTO> listagemTerminais = pa.Terminais.Select(terminal => new TerminalDTO()
            {
                IdUnidadeInst = terminal.IdUnidadeInst,
                NumTerminal = terminal.NumTerminal,
                IdTipoTerminal = terminal.IdTipoTerminal,
                NomeUsuario = terminal?.Usuario?.DescNomeUsuario ?? $"SEM NOME PREENCHIDO",
            }).ToList();

            foreach (TerminalDTO terminal in listagemTerminais)
            {
                var (limInferior, limSuperior) = listagemLimitesTerminais
                    .Where(lim => lim.IdPontoAtendimento == terminal.IdUnidadeInst && lim.CodigoTipoTerminal == terminal.IdTipoTerminal)
                    .Select(lim => (lim.LimInferior, lim.LimSuperior))
                    .FirstOrDefault();

                var mediana = (limInferior + limSuperior) / 2;

                terminal.LimInferior = limInferior;
                terminal.LimSuperior = limSuperior;
                terminal.Mediana = mediana;

                terminal.SaldoTotal = await CalcularSaldoTotalTerminal(terminal.IdUnidadeInst, terminal.NumTerminal);
            }

            paRetorno.Terminais = listagemTerminais;

            if (paRetorno == null)
            {
                return NotFound($"Não foram encontradas Unidades Instituições com o identificador informado.");
            }

            return paRetorno;
        }

        // GET: api/v1/UnidadeInstituicoes/5
        [HttpGet("{id}/{numTerminal}/{dataInicio}/{dataFim}")]
        public async Task<ActionResult<UnidadeInstituicaoDTO>> GetUnidadeInstituicao(int id, int numTerminal, DateTime dataInicio, DateTime dataFim)
        {
            decimal saldoTotalPA = await CalcularSaldoTotalPA(id);
            DateTime dataUltimoLancamentoPA = await BuscarDataUltimoLancamentoPA(id);

            UnidadeInstituicao pa = await _context.UnidadeInstituicoes
                .Include(pa => pa.Terminais.Where(terminal => terminal.NumTerminal == numTerminal))
                    .ThenInclude(terminal => terminal.Usuario)
                .Include(pa => pa.LimitesTerminais)
                .FirstOrDefaultAsync(pa => pa.IdUnidadeInst == id);

            UnidadeInstituicaoDTO? paRetorno = new UnidadeInstituicaoDTO()
            {
                IdUnidadeInst = pa.IdUnidadeInst,
                NomeUnidade = pa.NomeUnidade,
                CodTipoUnidade = pa.CodTipoUnidade,
                SaldoTotal = saldoTotalPA,
                DataUltimaAtualizacao = dataUltimoLancamentoPA,
            };

            List<LimitesTerminalDTO> listagemLimitesTerminais = pa.LimitesTerminais.Select(lim => new LimitesTerminalDTO()
            {
                IdPontoAtendimento = lim.IdPontoAtendimento,
                CodigoTipoTerminal = lim.CodigoTipoTerminal,
                LimInferior = lim.LimInferior,
                LimSuperior = lim.LimSuperior,
            }).ToList();

            TerminalDTO terminal = pa.Terminais.Select(terminal => new TerminalDTO()
            {
                IdUnidadeInst = terminal.IdUnidadeInst,
                NumTerminal = terminal.NumTerminal,
                IdTipoTerminal = terminal.IdTipoTerminal,
                NomeUsuario = terminal?.Usuario?.DescNomeUsuario ?? $"SEM NOME PREENCHIDO",
            }).FirstOrDefault();

            List<MovimentacaoPA?> movimentacoes = await _context.MovimentacoesPAs.
                Where(mov => mov.IdPontoAtendimento == terminal.IdUnidadeInst &&
                mov.NumTerminal == terminal.NumTerminal &&
                mov.DataLancamento >= dataInicio &&
                mov.DataLancamento <= dataFim)
                .Include(mov => mov.TiposOperacao)
                .ToListAsync();

            var (limInferior, limSuperior) = listagemLimitesTerminais
                .Where(lim => lim.IdPontoAtendimento == terminal.IdUnidadeInst && lim.CodigoTipoTerminal == terminal.IdTipoTerminal)
                .Select(lim => (lim.LimInferior, lim.LimSuperior))
                .FirstOrDefault();

            var mediana = (limInferior + limSuperior) / 2;

            terminal.LimInferior = limInferior;
            terminal.LimSuperior = limSuperior;
            terminal.Mediana = mediana;

            terminal.SaldoTotal = await CalcularSaldoTotalTerminal(terminal.IdUnidadeInst, terminal.NumTerminal);

            terminal.Movimentacoes = movimentacoes.Select(mov => new MovimentacaoPADTO()
            {
                DataLancamento = mov.DataLancamento,
                NumTerminal = mov.NumTerminal,
                CodigoOperacao = $"{mov.IdGrupoOpCaixa:00}/{mov.IdOperacaoCaixa:00}",
                IdGrupoOpCaixa = mov.IdGrupoOpCaixa,
                IdOperacaoCaixa = mov.IdOperacaoCaixa,
                DescOperacao = mov.TiposOperacao?.DescricaoOperacao,
                Valor = mov.TiposOperacao.Sensibilizacao.HasValue && mov.TiposOperacao.Sensibilizacao.Value ? mov.Valor : - mov.Valor,
                Historico = mov.Historico,
                DescHistorico = mov.TiposOperacao?.DescricaoHistorico,
            }).ToList();

            paRetorno.Terminais.Add(terminal);

            if (paRetorno == null)
            {
                return NotFound($"Não foram encontradas Unidades Instituições com o identificador informado.");
            }

            return paRetorno;
        }

        private async Task<decimal> CalcularSaldoTotalPA(int idPA)
        {
            decimal saldoPositivo = await _context.MovimentacoesPAs
                .Where(mov => mov.IdPontoAtendimento == idPA && mov.TiposOperacao.Sensibilizacao == true).SumAsync(mov => mov.Valor);

            decimal saldoNegativo = await _context.MovimentacoesPAs
                .Where(mov => mov.IdPontoAtendimento == idPA && mov.TiposOperacao.Sensibilizacao == true).SumAsync(mov => mov.Valor);

            return saldoPositivo - saldoNegativo;
        }

        private async Task<decimal> CalcularSaldoTotalTerminal(int idPA, int numTerminal)
        {
            decimal saldoPositivo = await _context.MovimentacoesPAs
                .Where(mov => mov.IdPontoAtendimento == idPA && mov.NumTerminal == numTerminal && mov.TiposOperacao.Sensibilizacao == true).SumAsync(mov => mov.Valor);

            decimal saldoNegativo = await _context.MovimentacoesPAs
                .Where(mov => mov.IdPontoAtendimento == idPA && mov.NumTerminal == numTerminal && mov.TiposOperacao.Sensibilizacao == true).SumAsync(mov => mov.Valor);

            return saldoPositivo - saldoNegativo;
        }

        private async Task<DateTime> BuscarDataUltimoLancamentoPA (int idPA)
        {
            DateTime dataUltimoLancamento = await _context.MovimentacoesPAs
                .Where(mov => mov.IdPontoAtendimento == idPA && mov.TiposOperacao.Sensibilizacao != null)
                .OrderByDescending(mov => mov.DataLancamento)
                .Select(mov => mov.DataLancamento)
                .FirstOrDefaultAsync();

            return dataUltimoLancamento;
        }
    }
}
