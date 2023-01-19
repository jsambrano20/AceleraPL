using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_MYSQL.Data;
using API_MYSQL.Model;

namespace API_MYSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alunos>>> Getalunos()
        {
            return await _context.alunos.ToListAsync();
        }

        // GET: api/Alunos/5
        [HttpGet("AlunoID/{id}")]
        public async Task<ActionResult<Alunos>> GetAlunos(int id)
        {
            var alunos = await _context.alunos.FindAsync(id);

            if (alunos == null)
            {
                return NotFound();
            }

            return alunos;
        }
        // GET: api/Alunos/Nome
        [HttpGet("NomeAluno/{nome}")]
        public async Task<ActionResult<Alunos>> GetAlunosNome(string nome)
        {
            var alunos = await _context.alunos.FindAsync(nome);

            if (alunos == null)
            {
                return NotFound();
            }

            return alunos;
        }


        // PUT: api/Alunos/5
        [HttpPut("UpdateAluno/{id}")]
        public async Task<IActionResult> PutAlunos(int id, Alunos alunos)
        {
            if (id != alunos.id)
            {
                return BadRequest();
            }

            _context.Entry(alunos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunosExists(id))
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

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult<Alunos>> PostAlunos(Alunos alunos)
        {
            _context.alunos.Add(alunos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlunos", new { id = alunos.id }, alunos);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("AlunoDelete/{id}")]
        public async Task<IActionResult> DeleteAlunos(int id)
        {
            var alunos = await _context.alunos.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }

            _context.alunos.Remove(alunos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunosExists(int id)
        {
            return _context.alunos.Any(e => e.id == id);
        }
    }
}
