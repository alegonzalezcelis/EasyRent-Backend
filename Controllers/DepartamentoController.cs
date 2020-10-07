using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;  

namespace contactos.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly ContactosContext _context;

        public DepartamentoController(ContactosContext context)
        {
            _context = context;
        }

        // METODO GET TODOS LOS REGISTROS
        [HttpGet]
        [Authorize]
        public IEnumerable<Departamento> GetAll()
        {
            return _context.Departamento.ToList();
        }

        // METODO GET, REGISTRO POR ID
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Contacto>> GetById(long id)
        {
            var item = await _context.Contacto.FindAsync(id);
            if(item==null)
            {
                return NotFound();
            }

            return item;
        }

        // Crear Registro si estoy autorizado
        [HttpPost, Authorize]
        public async Task<ActionResult<Departamento>> Create([FromBody] Departamento item)
        {
            if(item==null)
            {
                return BadRequest();
            }

            var currentUser = HttpContext.User;
            // int years = 0;

            // if (currentUser.HasClaim(c => c.Type == "FechaCreado"))
            // {
            //     DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "FechaCreado").Value);
            //     years = DateTime.Today.Year - date.Year;
            // }

            // if (years < 2)
            // {
            //     return Forbid( );
            // }

            _context.Departamento.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = item.id}, item);
        }

        // Actualizar por id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Departamento item)
        {
            if(item == null || id==0)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Borrar por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var departamento = await _context.Departamento.FindAsync(id);

            if(departamento==null)
            {
                return NotFound();
            }

            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}