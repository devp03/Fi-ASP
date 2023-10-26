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
    public class PersonaDatos
    {
        private ConexionDB conexion;

        public PersonaDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO persona(id_persona, idfk_ciudad, nombre, apellido, tipodocumento, nrodocumento, direccion, celular" +
                "email, estado) "
                + "VALUES(@id_persona, @idfk_ciudad, @nombre, @apellido, @tipodocumento, @nrodocumento, @direccion, @celular, @email, estado", conn);
            comando.Parameters.AddWithValue("id_persona", persona.id_persona);
            comando.Parameters.AddWithValue("idfk_ciudad", persona.idfk_ciudad);
            comando.Parameters.AddWithValue("nombre", persona.nombre);
            comando.Parameters.AddWithValue("apellido", persona.apellido);
            comando.Parameters.AddWithValue("tipodocumento", persona.tipodocumento);
            comando.Parameters.AddWithValue("nrodocumento", persona.nrodocumento);
            comando.Parameters.AddWithValue("direccion", persona.direccion);
            comando.Parameters.AddWithValue("celular", persona.celular);
            comando.Parameters.AddWithValue("email", persona.email);
            comando.Parameters.AddWithValue("estado", persona.estado);
           



            comando.ExecuteNonQuery();
        }

        public PersonaModel obtenerPersonaPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * From persona where id_persona = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new PersonaModel
                {
                    id_persona = reader.GetInt32("id_persona"),
                    idfk_ciudad = reader.GetInt32("idfk_ciudad"),
                    nombre = reader.GetString("nombre"),
                    apellido = reader.GetString("apellido"),
                    tipodocumento = reader.GetString("tipodocumento"),
                    nrodocumento = reader.GetString("nrodocumento"),
                    direccion = reader.GetString("direccion"),
                    celular = reader.GetString("celular"),
                    email = reader.GetString("email"),
                    estado = reader.GetString("estado"),
                    

                };
            }
            return null;
        }

        public void modificarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE persona SET  nombre= '{persona.nombre}, apellido = {persona.apellido}, " +
                $"tipodocumento={persona.tipodocumento}, nrodocumento={persona.nrodocumento}, direccion={persona.direccion}, celular={persona.celular} " +
                $"email={persona.email}, estado = {persona.estado}  ' WHERE id_persona = {persona.id_persona}", conn);
            comando.ExecuteNonQuery();

        }

        public void eliminarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM persona WHERE id_persona = {persona.id_persona}", conn);
            comando.ExecuteNonQuery();
        }
    }
}
}
