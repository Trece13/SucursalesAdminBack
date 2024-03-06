using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SucursalesAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private MyDbContext _context;

        public SucursalesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Sucursal> GetSucursals() => _context.Sucursales.ToList();

        public IEnumerable<Moneda> GetMonedas() => _context.Monedas.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursalById(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return sucursal;
        }

        [HttpPost]
        public async Task<ActionResult<Sucursal>> CreateSucursal([FromBody] Sucursal newSucursal)
        {
            _context.Sucursales.Add(newSucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSucursals), new { id = newSucursal.Codigo }, newSucursal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSucursal(int id, [FromBody] Sucursal updatedSucursal)
        {
            if (id != updatedSucursal.Codigo)
            {
                return BadRequest();
            }

            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            sucursal.Descripcion = updatedSucursal.Descripcion;
            sucursal.Direccion = updatedSucursal.Direccion;
            sucursal.Identificacion = updatedSucursal.Identificacion;
            sucursal.MonedaId = updatedSucursal.MonedaId;

            _context.Entry(sucursal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Sucursales.Any(e => e.Codigo == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
