using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosServices
{
    public class UsuarioService
    {
        UsuarioDatos usuarioDatos;
        public UsuarioService(string cadenaConexion)
        {
            usuarioDatos = new UsuarioDatos(cadenaConexion);
        }

        public void insertarUsuario(UsuarioModel usuario)
        {
           
            usuarioDatos.insertarUsuario(usuario);
        }

        public UsuarioModel obtenerUsuarioPorId(int id)
        {
            return usuarioDatos.obtenerUsuarioPorId(id);
        }

        public void modificarUsuario(UsuarioModel usuario)
        {
            
            usuarioDatos.modificarUsuario(usuario);
        }

        public void eliminarUsuario(UsuarioModel usuario)
        {
            
            usuarioDatos.eliminarUsuario(usuario);
        }

        public void ReiniciarIntentosFallidos(int idUsuario)
        {
            var usuario = obtenerUsuarioPorId(idUsuario);

            if (usuario != null)
            {
                // Reinicia los intentos fallidos a 0
                usuario.intentosFallidos = 0;

                // Actualiza el usuario en la base de datos
                modificarUsuario(usuario);
            }
       
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
                        usuario.intentosFallidos = 0; // Reinicia los intentos fallidos al bloquear
                    }

                    modificarUsuario(usuario);

                    return false;
                }
            }

            return false; // Usuario no encontrado
        }




    }

}
