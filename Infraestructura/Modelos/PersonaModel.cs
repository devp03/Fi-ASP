using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class PersonaModel
    {
        public int id_persona { get; set; }
        public int idfk_ciudad {  get; set; }
        public string nombre {  get; set; }
        public string apellido {  get; set; }
        public string tipodocumento { get; set; }
        public string nrodocumento {  get; set; }
        public string direccion { get; set; }
        public string celular {  get; set; }
        public string email {  get; set; }
        public string estado {  get; set; }
        public PersonaModel() { }
    }
}
