using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class UsuarioModel
    {
        public int id_Usuario {  get; set; }
        public int id_persona { get; set; }
        public string nombre_usuario { get; set; }
        public string contrasena {  get; set; }
        public string nivel {  get; set; }
        public string estado {  get; set; }
        public int intentosFallidos { get; set; }
        public UsuarioModel() { }

    }
}
