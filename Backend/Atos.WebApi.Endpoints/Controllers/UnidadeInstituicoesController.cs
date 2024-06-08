using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/UnidadeInstituicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeInstituicao>>> GetUnidadeInstituicoes()
        {
            return await _context.UnidadeInstituicoes.ToListAsync();
        }

        // GET: api/UnidadeInstituicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeInstituicao>> GetUnidadeInstituicao(int id)
        {
            var unidadeInstituicao = await _context.UnidadeInstituicoes.FindAsync(id);

            if (unidadeInstituicao == null)
            {
                return NotFound();
            }

            return unidadeInstituicao;
        }

        // PUT: api/UnidadeInstituicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadeInstituicao(int id, UnidadeInstituicao unidadeInstituicao)
        {
            if (id != unidadeInstituicao.IdUnidadeInst)
            {
                return BadRequest();
            }

            _context.Entry(unidadeInstituicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeInstituicaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UnidadeInstituicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadeInstituicao>> PostUnidadeInstituicao(UnidadeInstituicao unidadeInstituicao)
        {
            _context.UnidadeInstituicoes.Add(unidadeInstituicao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnidadeInstituicaoExists(unidadeInstituicao.IdUnidadeInst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnidadeInstituicao", new { id = unidadeInstituicao.IdUnidadeInst }, unidadeInstituicao);
        }

        // DELETE: api/UnidadeInstituicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeInstituicao(int id)
        {
            var unidadeInstituicao = await _context.UnidadeInstituicoes.FindAsync(id);
            if (unidadeInstituicao == null)
            {
                return NotFound();
            }

            _context.UnidadeInstituicoes.Remove(unidadeInstituicao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeInstituicaoExists(int id)
        {
            return _context.UnidadeInstituicoes.Any(e => e.IdUnidadeInst == id);
        }
    }
}
