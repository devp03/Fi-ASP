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
    public class MovimientoDatos
    {
        private ConexionDB conexion;

        public MovimientoDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarMovimiento(MovimientoModel movimiento)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO movimientos(id_movimientos, idfk_cuentas, fechamovimiento, tipomovimiento, saldoanterior, saldoactual, montomovimiento, cuentaorigen" +
                "cuentadestino, canal) "
                + "VALUES(@id_movimientos, @idfk_cuentas, @fechamovimiento, @tipomovimiento, @saldoanterior, @saldoactual, @montomovimiento, @cuentaorigen, @cuentadestino, canal", conn);
            comando.Parameters.AddWithValue("id_movimientos", movimiento.id_movimientos);
            comando.Parameters.AddWithValue("idfk_cuentas", movimiento.idfk_cuentas);
            comando.Parameters.AddWithValue("fechamovimiento", movimiento.fechamovimiento);
            comando.Parameters.AddWithValue("tipomovimiento", movimiento.tipomovimiento);
            comando.Parameters.AddWithValue("saldoanterior", movimiento.saldoanterior);
            comando.Parameters.AddWithValue("saldoactual", movimiento.saldoactual);
            comando.Parameters.AddWithValue("montomovimiento", movimiento.montomovimiento);
            comando.Parameters.AddWithValue("cuentaorigen", movimiento.cuentaorigen);
            comando.Parameters.AddWithValue("cuentadestino", movimiento.cuentadestino);
            comando.Parameters.AddWithValue("canal", movimiento.canal);
           


            comando.ExecuteNonQuery();
        }

        public MovimientoModel obtenerMovimientoPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * From movimientos where id_movimientos = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new MovimientoModel
                {
                    id_movimientos = reader.GetInt32("id_movimientos"),
                    idfk_cuentas = reader.GetInt32("idfk_cuentas"),
                    fechamovimiento = reader.GetDateTime("fechamovimiento"),
                    tipomovimiento = reader.GetString("tipomovimiento"),
                    saldoanterior = reader.GetFloat("saldoanterior"),
                    saldoactual = reader.GetFloat("saldoactual"),
                    montomovimiento = reader.GetFloat("montomovimiento"),
                    cuentaorigen = reader.GetFloat("cuentaorigen"),
                    cuentadestino = reader.GetFloat("cuentadestino"),
                    canal = reader.GetFloat("canal")

                };
            }
            return null;
        }

        public void modificarMovimiento(MovimientoModel movimiento)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE movimientos SET  fechamovimiento= '{movimiento.fechamovimiento}, tipomovimiento = {movimiento.tipomovimiento}, " +
                $"saldoanterior={movimiento.saldoanterior}, saldoactual={movimiento.saldoactual}, montomovimiento={movimiento.montomovimiento}, cuentaorigen={movimiento.cuentaorigen} " +
                $"cuentadestino={movimiento.cuentadestino}, canal = {movimiento.canal}  ' WHERE id_movimientos = {movimiento.id_movimientos}", conn);
            comando.ExecuteNonQuery();

        }

        public void eliminarMovimiento(MovimientoModel movimiento)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM movimientos WHERE id_movimientos = {movimiento.id_movimientos}", conn);
            comando.ExecuteNonQuery();
        }
    }
}
