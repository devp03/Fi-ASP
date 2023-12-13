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
    public class UsuarioDatos
    {
        private ConexionDB conexion;

        public UsuarioDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarUsuario(UsuarioModel usuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO usuarios(id_Usuario, id_persona, nombre_usuario, contrasena, nivel, estado) "
                + "VALUES(@id_Usuario, @id_persona, @nombre_usuario, @contrasena, @nivel, estado", conn);
            comando.Parameters.AddWithValue("id_Usuario", usuario.id_Usuario);
            comando.Parameters.AddWithValue("id_persona", usuario.id_persona);
            comando.Parameters.AddWithValue("nombre_usuario", usuario.nombre_usuario);
            comando.Parameters.AddWithValue("contrasena", usuario.contrasena);
            comando.Parameters.AddWithValue("nivel", usuario.nivel);
            comando.Parameters.AddWithValue("estado", usuario.estado);





            comando.ExecuteNonQuery();
        }

        public UsuarioModel obtenerUsuarioPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * From usuarios where id_Usuario = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new UsuarioModel
                {
                    id_Usuario = reader.GetInt32("id_Usuario"),
                    id_persona = reader.GetInt32("id_persona"),
                    nombre_usuario = reader.GetString("nombre_usuario"),
                    contrasena = reader.GetString("contrasena"),
                    nivel = reader.GetString("nivel"),
                    estado = reader.GetString("estado"),


                };
            }
            return null;
        }

        public void modificarUsuario(UsuarioModel usuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE usuarios SET  nombre_usuario= '{usuario.nombre_usuario}, contrasena = {usuario.contrasena}," +
                $"nivel={usuario.nivel}, estado = {usuario.estado}  ' WHERE id_Usuario = {usuario.id_Usuario}", conn);
            comando.ExecuteNonQuery();

        }

        public void eliminarUsuario(UsuarioModel usuario)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM usuarios WHERE id_Usuario = {usuario.id_Usuario}", conn);
            comando.ExecuteNonQuery();
        }

        public bool VerificarContrasena(int idUsuario, string contrasena)
        {
            var usuario = obtenerUsuarioPorId(idUsuario);

            if (usuario != null)
            {
                if (usuario.estado == "Bloqueado")
                {
                    return false; // Usuario bloqueado
                }

                // Comparación directa de la contraseña
                if (usuario.contrasena == contrasena)
                {
                    usuario.intentosFallidos = 0;
                    modificarUsuario(usuario);
                    return true;
                }
                else
                {
                    usuario.intentosFallidos++;

                    if (usuario.intentosFallidos >= 3)
                    {
                        usuario.estado = "Bloqueado";
                    }

                    modificarUsuario(usuario);

                    return false;
                }
            }

            return false; // Usuario no encontrado
        }
    
}
}

