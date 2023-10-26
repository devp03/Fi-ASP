using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosServices
{
    public class MovimientoService
    {
        MovimientoDatos movimientoDatos;
        public MovimientoService(string cadenaConexion)
        {
            movimientoDatos = new MovimientoDatos(cadenaConexion);
        }

        public void insertarMovimiento(MovimientoModel movimiento)
        {
            validarDatos(movimiento);
            movimientoDatos.insertarMovimiento(movimiento);
        }

        public MovimientoModel obtenerMovimientoPorId(int id)
        {
            return movimientoDatos.obtenerMovimientoPorId(id);
        }

        public void modificarMovimiento(MovimientoModel movimiento)
        {
            validarDatos(movimiento);
            movimientoDatos.modificarMovimiento(movimiento);
        }

        public void eliminarMovimiento(MovimientoModel movimiento)
        {
            validarDatos(movimiento);
            movimientoDatos.eliminarMovimiento(movimiento);
        }

        private void validarDatos(MovimientoModel movimiento)
        {
            if (movimiento.tipomovimiento.Trim().Length < 5)
            {
                throw new Exception("La movimiento no debe estar nulo");
            }
            if (movimiento.saldoactual < 2)
            {
                throw new Exception("El saldo actual no debe estar nulo");
            }
            if (movimiento.saldoanterior < 5)
            {
                throw new Exception("El saldo anterior no debe estar nulo");
            }
            if(movimiento.montomovimiento < 5)
            {
                throw new Exception("El monto movimiento no debe estar nulo");
            }
            if(movimiento.cuentadestino < 5)
            {
                throw new Exception("La cuenta de destino no debe estar nulo");
            }
            if(movimiento.canal < 5)
            {
                throw new Exception("El canal no debe estar nulo");
            }

            if (movimiento.cuentaorigen < 5)
            {
                throw new Exception("La cuenta de origen no debe estar nulo");
            }
        }

    }
}

