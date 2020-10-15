using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contactos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using contactos.Services;
using Microsoft.AspNetCore.Authorization;  

namespace contactos.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactosContext _context;

        public ContactController(ContactosContext context)
        {
            _context = context;
        }

        // METODO GET TODOS LOS REGISTROS

        // GET: api/v1/contact
        [HttpGet]
        [Authorize]
        public IEnumerable<Contacto> GetAll()
        {
            return _context.Contacto.ToList();
        }

        // METODO GET, REGISTRO POR ID

        //GET: // GET: api/v1/contact/1
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
        public async Task<ActionResult<Contacto>> Create([FromBody] Contacto item)
        {
            if(item==null)
            {
                return BadRequest();
            }

            // var currentUser = HttpContext.User;
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

            _context.Contacto.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = item.id}, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Contacto item)
        {
            if(item == null || id==0)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var contact = await _context.Contacto.FindAsync(id);

            if(contact==null)
            {
                return NotFound();
            }

            _context.Contacto.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}