using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiGeo.Models;

namespace ApiGeo.Data
{
    public class ApiGeoContext : DbContext
    {
        public ApiGeoContext (DbContextOptions<ApiGeoContext> options)
            : base(options)
        {
        }

        public DbSet<ApiGeo.Models.Ubicacion> Ubicacion { get; set; }
    }
}
