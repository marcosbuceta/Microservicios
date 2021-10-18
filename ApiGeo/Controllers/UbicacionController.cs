using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGeo.Data;
using ApiGeo.Models;

namespace ApiGeo.Controllers
{
    [Route("geolocalizar")]
    [Route("api/[controller]")]
   
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly ApiGeoContext _context;

        public UbicacionController(ApiGeoContext context)
        {
            _context = context;
        }

        // GET: api/Ubicacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicacion()
        {
            return await _context.Ubicacion.ToListAsync();
        }



        //[Route("api/geocodificar/GetUbicacion")]
        //[HttpGet]
        //GET: api/Ubicacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);

            if (ubicacion == null)
            {
                return NotFound();
            }
            return Ok(new { id = ubicacion.Id, latitud = ubicacion.Latitud, longitud = ubicacion.Longitud, estado = ubicacion.Estado });

            //return ubicacion;
        }

        // PUT: api/Ubicacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (id != ubicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(new { id = ubicacion.Id });
            //return NoContent();
        }

        // POST: api/Ubicacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        
        public async Task<ActionResult<Ubicacion>> PostUbicacion(Ubicacion ubicacion)
        {
            ubicacion.Estado = "PROCESANDO";
            _context.Ubicacion.Add(ubicacion);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUbicacion", new { id = ubicacion.Id }, ubicacion);
            return Accepted(new { id = ubicacion.Id });
        }

       
        private bool UbicacionExists(int id)
        {
            return _context.Ubicacion.Any(e => e.Id == id);
        }
    }
}
