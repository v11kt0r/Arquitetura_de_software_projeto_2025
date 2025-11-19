using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jogos.Data;
using jogos.Models;

namespace jogos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JogosController : ControllerBase
{
    private readonly AppDbContext _context;

    public JogosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Jogo>>> GetJogos()
    {
        return await _context.Jogos.Where(j => j.Ativo).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Jogo>> GetJogo(int id)
    {
        var jogo = await _context.Jogos.FindAsync(id);

        if (jogo == null || !jogo.Ativo)
        {
            return NotFound();
        }

        return jogo;
    }

    [HttpPost]
    public async Task<ActionResult<Jogo>> PostJogo(Jogo jogo)
    {
        _context.Jogos.Add(jogo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetJogo), new { id = jogo.Id }, jogo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutJogo(int id, Jogo jogo)
    {
        if (id != jogo.Id)
        {
            return BadRequest();
        }

        _context.Entry(jogo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JogoExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJogo(int id)
    {
        var jogo = await _context.Jogos.FindAsync(id);
        if (jogo == null)
        {
            return NotFound();
        }

        jogo.Ativo = false;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool JogoExists(int id)
    {
        return _context.Jogos.Any(e => e.Id == id);
    }
}