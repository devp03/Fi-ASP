using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class ClienteModel
    {

        public int id_cliente { get; set; }
        public int idfk_persona {  get; set; }
        public DateTime fechaingreso {  get; set; }
        public string calificacion { get; set; }
        public string estado { get; set; }
        public ClienteModel() { }
    }
}
