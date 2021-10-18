using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCodificador.Models;
using Geocoding.Google;

namespace GeoCodificador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionCodController : ControllerBase
    {


        [HttpPost]
        public async Task<ActionResult<UbicacionCod>> PostUbicacion(UbicacionCod ubicacion)
        {



            GoogleGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyB5aOz5ZmTu4rXM48J2JMjyMWvtPNALLt0" }; ;
            //IEnumerable<GoogleAddress> addresses = await geocoder.GeocodeAsync("1600 pennsylvania ave washington dc");
            IEnumerable<GoogleAddress> addresses = await geocoder.GeocodeAsync(ubicacion.Calle +" " + ubicacion.Numero + " " + ubicacion.Ciudad + " " + ubicacion.Provincia + " " + ubicacion.Pais);

            //seteo latitud y longitud..


            if (ubicacion == null)
            {
                return NotFound();
            }
        
            return Ok(new { id = ubicacion.Id, latitud = ubicacion.Latitud, longitud = ubicacion.Longitud });

        }


    }
}
