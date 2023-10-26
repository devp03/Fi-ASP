using Infraestructura.Conexiones;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class ClienteDatos
    {
        private ConexionDB conexion;

        public ClienteDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarCliente(ClienteModel cliente)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO cliente(id_cliente, idfk_persona, fechaingreso, calificacion, estado) "
                + "VALUES(@id_cliente, @idfk_persona, @fechaingreso, @calificacion, @estado)", conn);
            comando.Parameters.AddWithValue("id_cliente", cliente.id_cliente);
            comando.Parameters.AddWithValue("idfk_persona", cliente.idfk_persona);
            comando.Parameters.AddWithValue("fechaingreso", cliente.fechaingreso);
            comando.Parameters.AddWithValue("calificacion", cliente.calificacion);
            comando.Parameters.AddWithValue("estado", cliente.estado);
            comando.ExecuteNonQuery();
        }

        public ClienteModel obtenerClientePorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * From cliente where id_cliente = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new ClienteModel
                {
                    id_cliente = reader.GetInt32("id_cliente"),
                    idfk_persona = reader.GetInt32("idfk_persona"),
                    fechaingreso = reader.GetDateTime("fechaingreso"),
                    calificacion = reader.GetString("calificacion"),
                    estado = reader.GetString("estado")

                };
            }
            return null;
        }

        public void modificarCliente(ClienteModel cliente)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE cliente SET ciudad = '{cliente.estado}, calificacion = {cliente.calificacion}' WHERE id_ciudad = {cliente.id_cliente}", conn);
            comando.ExecuteNonQuery();

        }

        public void eliminarCliente(ClienteModel cliente)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM cliente WHERE id_cliente = {cliente.id_cliente}", conn);
            comando.ExecuteNonQuery();
        }
    }
}
