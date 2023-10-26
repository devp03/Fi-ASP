using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class CiudadModel
    {
        public int id_ciudad { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public int postal_code {  get; set; }
        public CiudadModel()
        {
        }
    }
}

