using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosServices
{
    public class CuentaService
    {
        CuentaDatos cuentaDatos;
        public CuentaService(string cadenaConexion)
        {
            cuentaDatos = new CuentaDatos(cadenaConexion);
        }

        public void insertarCuenta(CuentaModel cuenta)
        {
            validarDatos(cuenta);
            cuentaDatos.insertarCuenta(cuenta);
        }

        public CuentaModel obtenerCuentaPorId(int id)
        {
            return cuentaDatos.obtenerCuentaPorId(id);
        }

        public void modificarCuenta(CuentaModel cuenta)
        {
            validarDatos(cuenta);
            cuentaDatos.modificarCuenta(cuenta);
        }

        public void eliminarCuenta(CuentaModel cuenta)
        {
            validarDatos(cuenta);
            cuentaDatos.eliminarCuenta(cuenta);
        }

        private void validarDatos(CuentaModel cuenta)
        {
            if (cuenta.moneda.Trim().Length < 5)
            {
                throw new Exception("La moneda no debe estar nulo");
            }
            if (cuenta.nrocontrato.Trim().Length < 5)
            {
                throw new Exception("El numero de contrato no debe estar nulo");
            }
            if (cuenta.nrocuenta.Trim().Length < 5)
            {
                throw new Exception("El numero de cuenta no debe estar nulo");
            }
            if (cuenta.promedioacreditacion.Trim().Length < 5)
            {
                throw new Exception("El promedio de acreditacion no debe estar nulo");

            }
            if (cuenta.saldo < 5)
            {
                throw new Exception("El saldo no debe estar nulo");
            }
            if (cuenta.tipocuenta.Trim().Length < 5)
            {
                throw new Exception("El tipo de cuenta no debe estar nulo");
            }


        }

    }
}
