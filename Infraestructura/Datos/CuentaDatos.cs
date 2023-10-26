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
    public class CuentaDatos
    {
        private ConexionDB conexion;

        public CuentaDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarCuenta(CuentaModel cuenta)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO cuenta(id_cuentas, idfk_cliente, nrocuenta, fechaalta, tipocuenta, estado, saldo, nrocontrato" +
                "costomantenimiento, promedioacreditacion, moneda) "
                + "VALUES(@id_cuentas, @idfk_cliente, @nrocuenta, @fechaalta, @tipocuenta, @estado, @saldo, @nrocontrato, @costomantenimiento" +
                "@promedioacreditacion, @moneda)", conn);
            comando.Parameters.AddWithValue("id_cuentas", cuenta.id_cuentas);
            comando.Parameters.AddWithValue("idfk_cliente", cuenta.idfk_cliente);
            comando.Parameters.AddWithValue("nrocuenta", cuenta.nrocuenta);
            comando.Parameters.AddWithValue("fechaalta", cuenta.fechaalta);
            comando.Parameters.AddWithValue("tipocuenta", cuenta.tipocuenta);
            comando.Parameters.AddWithValue("estado", cuenta.estado);
            comando.Parameters.AddWithValue("saldo", cuenta.saldo);
            comando.Parameters.AddWithValue("nrocontrato", cuenta.nrocontrato);
            comando.Parameters.AddWithValue("costomantenimiento", cuenta.costomantenimiento);
            comando.Parameters.AddWithValue("promedioacreditacion", cuenta.promedioacreditacion);
            comando.Parameters.AddWithValue("moneda", cuenta.moneda);
            
            
            comando.ExecuteNonQuery();
        }

        public CuentaModel obtenerCuentaPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * From cuentas where id_cuentas = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new CuentaModel
                {
                    id_cuentas = reader.GetInt32("id_cuentas"),
                    idfk_cliente = reader.GetInt32("idfk_cliente"),
                    nrocuenta = reader.GetString("nrocuenta"),
                    fechaalta = reader.GetDateTime("fechaalta"),
                    tipocuenta = reader.GetString("tipocuenta"),
                    estado = reader.GetString("estado"),
                    saldo = reader.GetFloat("saldo"),
                    nrocontrato = reader.GetString("nrocontrato"),
                    costomantenimiento = reader.GetFloat("costomantenimiento"),
                    promedioacreditacion = reader.GetString("promedioacreditacion"),
                    moneda = reader.GetString("moneda")

                };
            }
            return null;
        }

        public void modificarCuenta(CuentaModel cuenta)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE cuenta SET  nrocuenta= '{cuenta.nrocuenta}, fechaalta = {cuenta.fechaalta}, " +
                $"tipocuenta={cuenta.tipocuenta}, estado={cuenta.estado}, saldo={cuenta.saldo}, nrocontrato={cuenta.nrocontrato} " +
                $"costomantenimiento={cuenta.costomantenimiento}, promedioacreditacion = {cuenta.promedioacreditacion}, moneda{cuenta.moneda}  ' WHERE id_cuenta = {cuenta.id_cuentas}", conn);
            comando.ExecuteNonQuery();

        }

        public void eliminarCuenta(CuentaModel cuenta)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM cuentas WHERE id_cuentas = {cuenta.id_cuentas}", conn);
            comando.ExecuteNonQuery();
        }
    }
}

