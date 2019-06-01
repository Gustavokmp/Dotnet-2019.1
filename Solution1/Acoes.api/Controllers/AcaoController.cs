using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acoes.api.date;
using Acoes.api.model;

namespace Acoes.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcaoController : ControllerBase
    {
        private readonly DataContext _context;

        public AcaoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Acao
        [HttpGet]
        public IEnumerable<Acao> GetAcoes()
        {
            return _context.Acoes;
        }

        // GET: api/Acao/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acao = await _context.Acoes.FindAsync(id);

            if (acao == null)
            {
                return NotFound();
            }

            return Ok(acao);
        }

        // PUT: api/Acao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcao([FromRoute] int id, [FromBody] Acao acao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acao.Id)
            {
                return BadRequest();
            }

            _context.Entry(acao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcaoExists(id))
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

        // POST: api/Acao
        [HttpPost]
        public async Task<IActionResult> PostAcao([FromBody] Acao acao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Acoes.Add(acao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcao", new { id = acao.Id }, acao);
        }

        // DELETE: api/Acao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acao = await _context.Acoes.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }

            _context.Acoes.Remove(acao);
            await _context.SaveChangesAsync();

            return Ok(acao);
        }

        private bool AcaoExists(int id)
        {
            return _context.Acoes.Any(e => e.Id == id);
        }
    }
}