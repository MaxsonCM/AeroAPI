using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AeroAPI.Model;
using AeroAPI.Models;

namespace AeroAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly AeroAPIContext _context;

        public PassageirosController(AeroAPIContext context)
        {
            _context = context;
        }

        // GET: Passageiros
        [HttpGet]
        public IEnumerable<Passageiro> GetPassageiro()
        {
            return _context.Passageiro;
        }

        // GET: Passageiros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassageiro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Passageiro = await _context.Passageiro.FindAsync(id);

            if (Passageiro == null)
            {
                return NotFound();
            }

            return Ok(Passageiro);
        }

        // PUT: Passageiros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassageiro([FromRoute] int id, [FromBody] Passageiro Passageiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Passageiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(Passageiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassageiroExists(id))
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

        // POST: Passageiros
        [HttpPost]
        public async Task<IActionResult> PostPassageiro([FromBody] Passageiro Passageiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Passageiro.Add(Passageiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassageiro", new { id = Passageiro.Id }, Passageiro);
        }

        // DELETE: Passageiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassageiro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Passageiro = await _context.Passageiro.FindAsync(id);
            if (Passageiro == null)
            {
                return NotFound();
            }

            _context.Passageiro.Remove(Passageiro);
            await _context.SaveChangesAsync();

            return Ok(Passageiro);
        }

        private bool PassageiroExists(int id)
        {
            return _context.Passageiro.Any(e => e.Id == id);
        }
    }
}