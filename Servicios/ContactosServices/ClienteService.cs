using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosServices
{
    public class ClienteService
    {
        ClienteDatos clienteDatos;
        public ClienteService(string cadenaConexion)
        {
            clienteDatos = new ClienteDatos(cadenaConexion);
        }

        public void insertarCliente(ClienteModel cliente)
        {
            validarDatos(cliente);
            clienteDatos.insertarCliente(cliente);
        }

        public ClienteModel obtenerClientePorId(int id)
        {
            return clienteDatos.obtenerClientePorId(id);
        }

        public void modificarCliente(ClienteModel cliente)
        {
            validarDatos(cliente);
            clienteDatos.modificarCliente(cliente);
        }

        public void eliminarCliente(ClienteModel cliente)
        {
            validarDatos(cliente);
            clienteDatos.eliminarCliente(cliente);
        }

        private void validarDatos(ClienteModel cliente)
        {
            if (cliente.calificacion.Trim().Length < 5)
            {
                throw new Exception("La calificacion no debe estar nulo");
            }
            if (cliente.estado.Trim().Length < 5)
            {
                throw new Exception("El estado no debe estar nulo");
            }
        }

    }
}
