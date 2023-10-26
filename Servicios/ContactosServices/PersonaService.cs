using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosServices
{
    public class PersonaService
    {
        PersonaDatos personaDatos;
        public PersonaService(string cadenaConexion)
        {
            personaDatos = new PersonaDatos(cadenaConexion);
        }

        public void insertarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.insertarPersona(persona);
        }

        public PersonaModel obtenerPersonaPorId(int id)
        {
            return personaDatos.obtenerPersonaPorId(id);
        }

        public void modificarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.modificarPersona(persona);
        }

        public void eliminarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.eliminarPersona(persona);
        }

        private void validarDatos(PersonaModel persona)
        {
            if (persona.nrodocumento.Trim().Length < 5)
            {
                throw new Exception("El numero de documento no debe estar nulo");
            }

            if (persona.nombre.Trim().Length < 5)
            {
                throw new Exception("El nombre no debe estar nulo");
            }




        }

    }
}
}
