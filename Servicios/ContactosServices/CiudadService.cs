using Infraestructura.Conexiones;
using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosServices
{
    public class CiudadService
    {
        CiudadDatos ciudadDatos;
        public CiudadService(string cadenaConexion)
        {
            ciudadDatos = new CiudadDatos(cadenaConexion);
        }

        public void insertarCiudad(CiudadModel ciudad)
        {
            validarDatos(ciudad);
            ciudadDatos.insertarCiudad(ciudad);
        }

        public CiudadModel obtenerCiudadPorId(int id)
        {
            return ciudadDatos.obtenerCiudadPorId(id);
        }

        public void modificarCiudad(CiudadModel ciudad)
        {
            validarDatos(ciudad);
            ciudadDatos.modificarCiudad(ciudad);
        }

        public void eliminarCiudad(CiudadModel ciudad)
        {
            validarDatos(ciudad);
            ciudadDatos.eliminarCiudad(ciudad);
        }

        private void validarDatos(CiudadModel ciudad)
        {
            if (ciudad.ciudad.Trim().Length < 5)
            {
                throw new Exception("La descripcion no debe estar nulo");
            }
        }

    }

       
}

