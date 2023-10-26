using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class CuentaModel
    {
        public int id_cuentas {  get; set; }
        public int idfk_cliente {  get; set; }
        public string nrocuenta { get; set; }
        public DateTime fechaalta { get; set; }
        public string tipocuenta {  get; set; }
        public string estado {  get; set; }
        public float saldo {  get; set; }
        public string nrocontrato {  get; set; }
        public float costomantenimiento { get; set; }
        public string promedioacreditacion {  get; set; }
        public string moneda {  get; set; }

        public CuentaModel() { }
    }
}
