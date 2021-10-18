using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGeo.Models
{
    public class Ubicacion
    {
        public int Id { get; set; }

        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public string Codigo_Postal { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Estado { get; set; }


    }
}
